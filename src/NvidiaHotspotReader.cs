/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace LibreHardwareMonitorAfterburnerPlugin;

/// <summary>
///     Reads the hidden thermal sensor channels of NVIDIA GeForce RTX 50 (Blackwell) GPUs.
/// </summary>
/// <remarks>
///     NVIDIA does not expose the Blackwell Hot Spot temperature through the public NVAPI.
///     The values are read directly from the GPU THERM block (BAR0 + 0xAD0A90) using the
///     PawnIO kernel driver and its official Nvidia module
///     (https://github.com/namazso/PawnIO.Modules, LGPL-2.1-or-later).
///
///     The module returns six raw DWORDs. Valid samples have bit 30 set and are decoded as
///     Q8.8 fixed point: (raw &amp; 0xFFFF) / 256.0 掳C. Channel 0 is the Hot Spot value
///     displayed by HWMonitor 1.65.1.
/// </remarks>
internal class NvidiaHotspotReader : IDisposable
{
    /// <summary>Number of thermal channels exposed by the module.</summary>
    public const int ChannelCount = 6;

    /// <summary>Bit that marks a thermal sample as valid.</summary>
    private const uint ThermalChannelValid = 1u << 30;

    /// <summary>Lower 16 bits contain the temperature as Q8.8 fixed point.</summary>
    private const uint ThermalChannelValueMask = 0xFFFF;

    /// <summary>Maximum accepted temperature in degrees Celsius.</summary>
    private const float MaxTemperatureCelsius = 130f;

    /// <summary>Reads are cached per GPU for this long to avoid hammering the kernel driver.</summary>
    private const int CacheMilliseconds = 100;

    private const string PawnIoDevicePath = @"\\?\GLOBALROOT\Device\PawnIO";
    private const string NvidiaModuleResource = "LibreHardwareMonitorAfterburnerPlugin.Nvidia.bin";
    private const string ThermalRegisterFunctionName = "ioctl_read_thermal_registers";
    private const int FunctionNameLength = 32;

    private const uint GenericRead = 0x80000000;
    private const uint GenericWrite = 0x40000000;
    private const uint FileShareRead = 1;
    private const uint FileShareWrite = 2;
    private const uint OpenExisting = 3;
    private const uint FileAttributeNormal = 0x80;

    // IOCTL control codes shared with LibreHardwareMonitor's PawnIo client.
    private const uint PawnIoDeviceType = 41394u << 16;
    private const uint PawnIoLoadBinary = 0x821u << 2;
    private const uint PawnIoExecute = 0x841u << 2;

    private const int NvApiOk = 0;
    private const int MaxPhysicalGpus = 64;

    private readonly SafeFileHandle _handle;
    private readonly List<Gpu> _gpus = [];
    private readonly List<float?[]> _temperatures = [];
    private readonly List<int> _lastUpdate = [];

    private static readonly StatusDelegate? NvApiInitialize;
    private static readonly EnumPhysicalGpusDelegate? NvApiEnumPhysicalGpus;
    private static readonly GetFullNameDelegate? NvApiGetFullName;
    private static readonly GetBusIdDelegate? NvApiGetBusId;
    private static readonly GetBusSlotIdDelegate? NvApiGetBusSlotId;

    /// <summary>
    ///     Whether reading is possible. False when the PawnIO driver is missing, the module
    ///     fails to load, no RTX 50 GPU is present or NVAPI is unavailable.
    /// </summary>
    public bool Available { get; private set; }

    /// <summary>Number of enumerated RTX 50 GPUs.</summary>
    public int GpuCount => _gpus.Count;

    public NvidiaHotspotReader()
    {
        _handle = OpenDevice();

        try
        {
            if (_handle.IsInvalid)
                return; // PawnIO driver is not installed.

            if (!LoadModule())
                return;

            if (NvApiEnumPhysicalGpus is null || NvApiGetFullName is null || NvApiGetBusId is null || NvApiGetBusSlotId is null)
                return;

            EnumerateBlackwellGpus();

            if (_gpus.Count == 0)
                return;

            for (int i = 0; i < _gpus.Count; i++)
            {
                _temperatures.Add(new float?[ChannelCount]);
                _lastUpdate.Add(0);
            }

            Available = true;
            Log($"NvidiaHotspotReader: Blackwell hotspot enabled for {_gpus.Count} GPU(s).");
        }
        catch (Exception e)
        {
            // Any failure leaves Available false and the plugin keeps working without
            // the Blackwell hotspot sensors.
            Log($"NvidiaHotspotReader: initialization failed: {e}");
        }
    }

    /// <summary>
    ///     Reads all thermal channels of a GPU. Results are cached for 100 ms per GPU to
    ///     avoid hammering the kernel driver during an Afterburner polling cycle.
    /// </summary>
    /// <returns>True when at least one valid channel was found, otherwise false.</returns>
    public bool TryReadChannels(int gpuIndex, out float?[] channels)
    {
        if (gpuIndex < 0 || gpuIndex >= _temperatures.Count)
        {
            channels = [];
            return false;
        }

        channels = _temperatures[gpuIndex];

        int now = Environment.TickCount;

        if (now - _lastUpdate[gpuIndex] < CacheMilliseconds)
            return true;

        _lastUpdate[gpuIndex] = now;
        Array.Clear(channels, 0, channels.Length);

        Gpu gpu = _gpus[gpuIndex];
        long[] raw = Execute(ThermalRegisterFunctionName, [gpu.Bus, gpu.Device, gpu.Function], ChannelCount);

        bool any = false;

        for (int i = 0; i < ChannelCount && i < raw.Length; i++)
        {
            uint value = unchecked((uint)raw[i]);

            // Valid samples have bit 30 set. 0xFF00 (the NVIDIA lock value) does not.
            if ((value & ThermalChannelValid) == 0)
                continue;

            float temperature = (value & ThermalChannelValueMask) / 256.0f;

            // Plausibility window, matching the range used by thermal analysis tools.
            if (temperature <= 0f || temperature > MaxTemperatureCelsius)
                continue;

            channels[i] = temperature;
            any = true;
        }

        return any;
    }

    public void Dispose()
    {
        if (!_handle.IsClosed)
            _handle.Dispose();
    }

    private void EnumerateBlackwellGpus()
    {
        var gpuHandles = new IntPtr[MaxPhysicalGpus];

        if (NvApiEnumPhysicalGpus!(gpuHandles, out int gpuCount) != NvApiOk || gpuCount <= 0)
            return;

        for (int i = 0; i < gpuCount; i++)
        {
            var name = new StringBuilder(64);

            if (NvApiGetFullName!(gpuHandles[i], name) != NvApiOk)
                continue;

            // .NET Framework doesn't have string.Contains(string, StringComparison),
            // so use IndexOf which is available since .NET Framework 2.0.
            if (name.ToString().IndexOf("RTX 50", StringComparison.OrdinalIgnoreCase) < 0)
                continue;

            if (NvApiGetBusId!(gpuHandles[i], out uint busId) != NvApiOk)
                continue;

            if (NvApiGetBusSlotId!(gpuHandles[i], out uint busSlotId) != NvApiOk)
                continue;

            _gpus.Add(new Gpu(busId, busSlotId, 0));
        }
    }

    private bool LoadModule()
    {
        using Stream stream = typeof(NvidiaHotspotReader).Assembly.GetManifestResourceStream(NvidiaModuleResource);

        if (stream is null)
            return false;

        using var memory = new MemoryStream();
        stream.CopyTo(memory);

        byte[] module = memory.ToArray();

        return DeviceIoControl(_handle, PawnIoDeviceType | PawnIoLoadBinary, module, (uint)module.Length, null, 0, out _, IntPtr.Zero);
    }

    private long[] Execute(string name, long[] input, int outLength)
    {
        var output = new byte[outLength * sizeof(long)];
        var totalInput = new byte[(input.Length * sizeof(long)) + FunctionNameLength];

        byte[] nameBytes = Encoding.ASCII.GetBytes(name);
        Buffer.BlockCopy(nameBytes, 0, totalInput, 0, Math.Min(FunctionNameLength - 1, nameBytes.Length));
        Buffer.BlockCopy(input, 0, totalInput, FunctionNameLength, input.Length * sizeof(long));

        uint read = 0;

        if (DeviceIoControl(_handle, PawnIoDeviceType | PawnIoExecute, totalInput, (uint)totalInput.Length, output, (uint)output.Length, out read, IntPtr.Zero))
        {
            var result = new long[read / sizeof(long)];
            Buffer.BlockCopy(output, 0, result, 0, (int)read);
            return result;
        }

        return new long[outLength];
    }

    private static SafeFileHandle OpenDevice()
    {
        return CreateFile(
            PawnIoDevicePath,
            GenericRead | GenericWrite,
            FileShareRead | FileShareWrite,
            IntPtr.Zero,
            OpenExisting,
            FileAttributeNormal,
            IntPtr.Zero);
    }

    private static T? GetDelegate<T>(uint interfaceId) where T : class
    {
        IntPtr ptr = NvApiQueryInterface(interfaceId);
        return ptr == IntPtr.Zero ? null : Marshal.GetDelegateForFunctionPointer<T>(ptr);
    }

    private static void Log(string message) => Exports.Log(message);

    static NvidiaHotspotReader()
    {
        try
        {
            NvApiInitialize = GetDelegate<StatusDelegate>(0x0150E828);

            if (NvApiInitialize?.Invoke() == NvApiOk)
            {
                NvApiEnumPhysicalGpus = GetDelegate<EnumPhysicalGpusDelegate>(0xE5AC921F);
                NvApiGetFullName = GetDelegate<GetFullNameDelegate>(0xCEEE8E9F);
                NvApiGetBusId = GetDelegate<GetBusIdDelegate>(0x1BE0B8E5);
                NvApiGetBusSlotId = GetDelegate<GetBusSlotIdDelegate>(0x2A0A350F);
            }
        }
        catch
        {
            // NVAPI is unavailable; the plugin simply won't add Blackwell hotspot sensors.
        }
    }

    [DllImport("nvapi.dll", EntryPoint = "nvapi_QueryInterface", CallingConvention = CallingConvention.Cdecl, PreserveSig = true)]
    private static extern IntPtr NvApiQueryInterface(uint interfaceId);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern SafeFileHandle CreateFile(
        string lpFileName,
        uint dwDesiredAccess,
        uint dwShareMode,
        IntPtr lpSecurityAttributes,
        uint dwCreationDisposition,
        uint dwFlagsAndAttributes,
        IntPtr hTemplateFile);

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool DeviceIoControl(
        SafeFileHandle hDevice,
        uint dwIoControlCode,
        byte[]? lpInBuffer,
        uint nInBufferSize,
        byte[]? lpOutBuffer,
        uint nOutBufferSize,
        out uint lpBytesReturned,
        IntPtr lpOverlapped);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int StatusDelegate();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int EnumPhysicalGpusDelegate([Out] IntPtr[] gpuHandles, out int gpuCount);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int GetFullNameDelegate(IntPtr gpuHandle, StringBuilder name);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int GetBusIdDelegate(IntPtr gpuHandle, out uint busId);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int GetBusSlotIdDelegate(IntPtr gpuHandle, out uint busSlotId);

    private readonly struct Gpu
    {
        public Gpu(uint bus, uint device, uint function)
        {
            Bus = bus;
            Device = device;
            Function = function;
        }

        public uint Bus { get; }

        public uint Device { get; }

        public uint Function { get; }
    }
}
