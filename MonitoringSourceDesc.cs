using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibreHardwareMonitorAfterburnerPlugin
{
    /// <summary>
    /// Converted from MSIAfterburnerMonitoringSourceDesc.h found in the SDK included with MSI Afterburner 4.6.3
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct MonitoringSourceDesc
    {
        const int MaxPath = 260;

        /// <summary>
        /// descriptor version ((major<<16) + minor)
        /// must be set to 0x00010000 or greater by host to use this structure
        ///
        /// Don't change this field when filling the descriptor!
        /// </summary>
        public uint dwVersion;

        /// <summary>
        /// data source name (e.g. "GPU temperature")
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MaxPath)]
        public string szName;

        /// <summary>
        /// data source units (e.g. "°C")
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MaxPath)]
        public string szUnits;

        /// <summary>
        /// optional output format, may be empty to specify default %.0f format
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MaxPath)]
        public string szFormat;

        /// <summary>
        /// data source group name used for grouping data by it in OSD, Logitech keyboard LCD etc 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MaxPath)]
        public string szGroup;

        /// <summary>
        /// data source ID, MONITORING_SOURCE_ID_...  
        /// </summary>
        public uint dwID;

        /// <summary>
        // zero based data source instance index, e.g. 0 for "GPU1 temperature" in multiGPU system, 1 for "GPU2 temperature" in multiGPU system etc
        /// </summary>
        public uint dwInstance;

        /// <summary>
        /// default maximum graph limit (e.g. 100°C)
        /// </summary>
        public float fltMaxLimit;

        /// <summary>
        /// default minimum graph limit (e.g. 0°C)
        /// </summary>
        public float fltMinLimit;

        /// <summary>
        /// optional data source name template for multiGPU system, e.g. "GPU%d temperature" for "GPU1 temperature" name 
        /// the template is used to allow the host to extract GPU/CPU/etc index from the name
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MaxPath)]
        public string szNameTemplate;

        /// <summary>
        /// optional data source group name template for multiGPU system, e.g. "GPU%d" for "GPU1" group name
        /// the template is used to allow the host to extract GPU/CPU/etc index from the group name
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MaxPath)]
        public string szGroupTemplate;
    }
}
