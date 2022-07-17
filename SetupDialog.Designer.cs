
namespace LibreHardwareMonitorAfterburnerPlugin
{
    partial class SetupDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupDialog));
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.sensorGroupSelections = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.mainboard = new System.Windows.Forms.CheckBox();
            this.cpu = new System.Windows.Forms.CheckBox();
            this.ram = new System.Windows.Forms.CheckBox();
            this.gpu = new System.Windows.Forms.CheckBox();
            this.fancontroller = new System.Windows.Forms.CheckBox();
            this.hdd = new System.Windows.Forms.CheckBox();
            this.network = new System.Windows.Forms.CheckBox();
            this.sensorFilters = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.temp = new System.Windows.Forms.CheckBox();
            this.fanRpm = new System.Windows.Forms.CheckBox();
            this.fanControl = new System.Windows.Forms.CheckBox();
            this.clock = new System.Windows.Forms.CheckBox();
            this.factor = new System.Windows.Forms.CheckBox();
            this.voltage = new System.Windows.Forms.CheckBox();
            this.power = new System.Windows.Forms.CheckBox();
            this.load = new System.Windows.Forms.CheckBox();
            this.flow = new System.Windows.Forms.CheckBox();
            this.misc = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.about = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.battery = new System.Windows.Forms.CheckBox();
            this.psu = new System.Windows.Forms.CheckBox();
            this.sensorGroupSelections.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.sensorFilters.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(435, 0);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 1;
            this.ok.Text = "Save";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(516, 0);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // sensorGroupSelections
            // 
            this.sensorGroupSelections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sensorGroupSelections.Controls.Add(this.flowLayoutPanel3);
            this.sensorGroupSelections.Location = new System.Drawing.Point(3, 57);
            this.sensorGroupSelections.Name = "sensorGroupSelections";
            this.sensorGroupSelections.Size = new System.Drawing.Size(292, 293);
            this.sensorGroupSelections.TabIndex = 4;
            this.sensorGroupSelections.TabStop = false;
            this.sensorGroupSelections.Text = "Active hardware groups";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.mainboard);
            this.flowLayoutPanel3.Controls.Add(this.cpu);
            this.flowLayoutPanel3.Controls.Add(this.ram);
            this.flowLayoutPanel3.Controls.Add(this.gpu);
            this.flowLayoutPanel3.Controls.Add(this.fancontroller);
            this.flowLayoutPanel3.Controls.Add(this.hdd);
            this.flowLayoutPanel3.Controls.Add(this.network);
            this.flowLayoutPanel3.Controls.Add(this.battery);
            this.flowLayoutPanel3.Controls.Add(this.psu);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(286, 274);
            this.flowLayoutPanel3.TabIndex = 7;
            // 
            // mainboard
            // 
            this.mainboard.AutoSize = true;
            this.mainboard.Checked = global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default.MainboardEnabled;
            this.mainboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mainboard.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default, "MainboardEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mainboard.Location = new System.Drawing.Point(3, 3);
            this.mainboard.Name = "mainboard";
            this.mainboard.Size = new System.Drawing.Size(76, 17);
            this.mainboard.TabIndex = 0;
            this.mainboard.Text = "Mainboard";
            this.mainboard.UseVisualStyleBackColor = true;
            // 
            // cpu
            // 
            this.cpu.AutoSize = true;
            this.cpu.Checked = global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default.CpuEnabled;
            this.cpu.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default, "CpuEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cpu.Location = new System.Drawing.Point(3, 26);
            this.cpu.Name = "cpu";
            this.cpu.Size = new System.Drawing.Size(78, 17);
            this.cpu.TabIndex = 1;
            this.cpu.Text = "Processors";
            this.cpu.UseVisualStyleBackColor = true;
            // 
            // ram
            // 
            this.ram.AutoSize = true;
            this.ram.Checked = global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default.RamEnabled;
            this.ram.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default, "RamEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ram.Location = new System.Drawing.Point(3, 49);
            this.ram.Name = "ram";
            this.ram.Size = new System.Drawing.Size(63, 17);
            this.ram.TabIndex = 2;
            this.ram.Text = "Memory";
            this.ram.UseVisualStyleBackColor = true;
            // 
            // gpu
            // 
            this.gpu.AutoSize = true;
            this.gpu.Checked = global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default.GpuEnabled;
            this.gpu.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default, "GpuEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gpu.Location = new System.Drawing.Point(3, 72);
            this.gpu.Name = "gpu";
            this.gpu.Size = new System.Drawing.Size(54, 17);
            this.gpu.TabIndex = 3;
            this.gpu.Text = "GPUs";
            this.gpu.UseVisualStyleBackColor = true;
            // 
            // fancontroller
            // 
            this.fancontroller.AutoSize = true;
            this.fancontroller.Checked = global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default.FanControllerEnabled;
            this.fancontroller.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default, "FanControllerEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fancontroller.Location = new System.Drawing.Point(3, 95);
            this.fancontroller.Name = "fancontroller";
            this.fancontroller.Size = new System.Drawing.Size(95, 17);
            this.fancontroller.TabIndex = 4;
            this.fancontroller.Text = "Fan controllers";
            this.fancontroller.UseVisualStyleBackColor = true;
            // 
            // hdd
            // 
            this.hdd.AutoSize = true;
            this.hdd.Checked = global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default.HddEnabled;
            this.hdd.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default, "HddEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.hdd.Location = new System.Drawing.Point(3, 118);
            this.hdd.Name = "hdd";
            this.hdd.Size = new System.Drawing.Size(63, 17);
            this.hdd.TabIndex = 5;
            this.hdd.Text = "Storage";
            this.hdd.UseVisualStyleBackColor = true;
            // 
            // network
            // 
            this.network.AutoSize = true;
            this.network.Checked = global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default.NetworkEnabled;
            this.network.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default, "NetworkEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.network.Location = new System.Drawing.Point(3, 141);
            this.network.Name = "network";
            this.network.Size = new System.Drawing.Size(66, 17);
            this.network.TabIndex = 6;
            this.network.Text = "Network";
            this.network.UseVisualStyleBackColor = true;
            // 
            // sensorFilters
            // 
            this.sensorFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sensorFilters.Controls.Add(this.flowLayoutPanel2);
            this.sensorFilters.Location = new System.Drawing.Point(301, 57);
            this.sensorFilters.Name = "sensorFilters";
            this.sensorFilters.Size = new System.Drawing.Size(293, 293);
            this.sensorFilters.TabIndex = 5;
            this.sensorFilters.TabStop = false;
            this.sensorFilters.Text = "Active sensor types";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.temp);
            this.flowLayoutPanel2.Controls.Add(this.fanRpm);
            this.flowLayoutPanel2.Controls.Add(this.fanControl);
            this.flowLayoutPanel2.Controls.Add(this.clock);
            this.flowLayoutPanel2.Controls.Add(this.factor);
            this.flowLayoutPanel2.Controls.Add(this.voltage);
            this.flowLayoutPanel2.Controls.Add(this.power);
            this.flowLayoutPanel2.Controls.Add(this.load);
            this.flowLayoutPanel2.Controls.Add(this.flow);
            this.flowLayoutPanel2.Controls.Add(this.misc);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(287, 274);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // temp
            // 
            this.temp.AutoSize = true;
            this.temp.Checked = global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default.TemperatureEnabled;
            this.temp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.temp.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default, "TemperatureEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.temp.Location = new System.Drawing.Point(3, 3);
            this.temp.Name = "temp";
            this.temp.Size = new System.Drawing.Size(106, 17);
            this.temp.TabIndex = 0;
            this.temp.Text = "Temperature (°C)";
            this.temp.UseVisualStyleBackColor = true;
            // 
            // fanRpm
            // 
            this.fanRpm.AutoSize = true;
            this.fanRpm.Checked = global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default.FanSpeedEnabled;
            this.fanRpm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fanRpm.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default, "FanSpeedEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fanRpm.Location = new System.Drawing.Point(3, 26);
            this.fanRpm.Name = "fanRpm";
            this.fanRpm.Size = new System.Drawing.Size(109, 17);
            this.fanRpm.TabIndex = 4;
            this.fanRpm.Text = "Fan speed (RPM)";
            this.fanRpm.UseVisualStyleBackColor = true;
            // 
            // fanControl
            // 
            this.fanControl.AutoSize = true;
            this.fanControl.Checked = global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default.ControlEnabled;
            this.fanControl.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default, "ControlEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fanControl.Location = new System.Drawing.Point(3, 49);
            this.fanControl.Name = "fanControl";
            this.fanControl.Size = new System.Drawing.Size(93, 17);
            this.fanControl.TabIndex = 6;
            this.fanControl.Text = "Fan speed (%)";
            this.fanControl.UseVisualStyleBackColor = true;
            // 
            // clock
            // 
            this.clock.AutoSize = true;
            this.clock.Checked = global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default.ClockEnabled;
            this.clock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.clock.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default, "ClockEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.clock.Location = new System.Drawing.Point(3, 72);
            this.clock.Name = "clock";
            this.clock.Size = new System.Drawing.Size(105, 17);
            this.clock.TabIndex = 1;
            this.clock.Text = "Frequency (Mhz)";
            this.clock.UseVisualStyleBackColor = true;
            // 
            // factor
            // 
            this.factor.AutoSize = true;
            this.factor.Checked = global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default.FactorEnabled;
            this.factor.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default, "FactorEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.factor.Location = new System.Drawing.Point(3, 95);
            this.factor.Name = "factor";
            this.factor.Size = new System.Drawing.Size(72, 17);
            this.factor.TabIndex = 11;
            this.factor.Text = "Multipliers";
            this.factor.UseVisualStyleBackColor = true;
            // 
            // voltage
            // 
            this.voltage.AutoSize = true;
            this.voltage.Checked = global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default.VoltageEnabled;
            this.voltage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.voltage.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default, "VoltageEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.voltage.Location = new System.Drawing.Point(3, 118);
            this.voltage.Name = "voltage";
            this.voltage.Size = new System.Drawing.Size(62, 17);
            this.voltage.TabIndex = 2;
            this.voltage.Text = "Voltage";
            this.voltage.UseVisualStyleBackColor = true;
            // 
            // power
            // 
            this.power.AutoSize = true;
            this.power.Checked = global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default.PowerEnabled;
            this.power.CheckState = System.Windows.Forms.CheckState.Checked;
            this.power.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default, "PowerEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.power.Location = new System.Drawing.Point(3, 141);
            this.power.Name = "power";
            this.power.Size = new System.Drawing.Size(76, 17);
            this.power.TabIndex = 9;
            this.power.Text = "Power (W)";
            this.power.UseVisualStyleBackColor = true;
            // 
            // load
            // 
            this.load.AutoSize = true;
            this.load.Checked = global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default.LoadEnabled;
            this.load.CheckState = System.Windows.Forms.CheckState.Checked;
            this.load.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default, "LoadEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.load.Location = new System.Drawing.Point(3, 164);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(67, 17);
            this.load.TabIndex = 3;
            this.load.Text = "Load (%)";
            this.load.UseVisualStyleBackColor = true;
            // 
            // flow
            // 
            this.flow.AutoSize = true;
            this.flow.Checked = global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default.FlowEnabled;
            this.flow.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default, "FlowEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flow.Location = new System.Drawing.Point(3, 187);
            this.flow.Name = "flow";
            this.flow.Size = new System.Drawing.Size(80, 17);
            this.flow.TabIndex = 5;
            this.flow.Text = "Flow speed";
            this.flow.UseVisualStyleBackColor = true;
            // 
            // misc
            // 
            this.misc.AutoSize = true;
            this.misc.Checked = global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default.MiscEnabled;
            this.misc.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default, "MiscEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.misc.Location = new System.Drawing.Point(3, 210);
            this.misc.Name = "misc";
            this.misc.Size = new System.Drawing.Size(227, 17);
            this.misc.TabIndex = 10;
            this.misc.Text = "Misc (data sizes, network and storage info)";
            this.misc.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.sensorGroupSelections, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sensorFilters, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(597, 353);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 0, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(594, 41);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select which hardware and sensor types to activate. What sensors are discovered w" +
    "ill depend on the system hardware and whether it is supported by Libre Hardware " +
    "Monitor.\r\n\r\n";
            // 
            // about
            // 
            this.about.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.about.Location = new System.Drawing.Point(6, 0);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(75, 23);
            this.about.TabIndex = 3;
            this.about.Text = "About...";
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.About_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.about);
            this.panel1.Controls.Add(this.ok);
            this.panel1.Controls.Add(this.cancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 353);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 26);
            this.panel1.TabIndex = 7;
            // 
            // battery
            // 
            this.battery.AutoSize = true;
            this.battery.Checked = global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default.BatteryEnabled;
            this.battery.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default, "BatteryEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.battery.Location = new System.Drawing.Point(3, 164);
            this.battery.Name = "battery";
            this.battery.Size = new System.Drawing.Size(59, 17);
            this.battery.TabIndex = 7;
            this.battery.Text = "Battery";
            this.battery.UseVisualStyleBackColor = true;
            // 
            // psu
            // 
            this.psu.AutoSize = true;
            this.psu.Checked = global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default.PsuEnabled;
            this.psu.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LibreHardwareMonitorAfterburnerPlugin.Properties.Settings.Default, "PsuEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.psu.Location = new System.Drawing.Point(3, 187);
            this.psu.Name = "psu";
            this.psu.Size = new System.Drawing.Size(48, 17);
            this.psu.TabIndex = 8;
            this.psu.Text = "PSU";
            this.psu.UseVisualStyleBackColor = true;
            // 
            // SetupDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 379);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Libre Hardware Monitor Plug-in Setup";
            this.sensorGroupSelections.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.sensorFilters.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox mainboard;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.GroupBox sensorGroupSelections;
        private System.Windows.Forms.CheckBox cpu;
        private System.Windows.Forms.CheckBox ram;
        private System.Windows.Forms.CheckBox gpu;
        private System.Windows.Forms.CheckBox fancontroller;
        private System.Windows.Forms.CheckBox hdd;
        private System.Windows.Forms.GroupBox sensorFilters;
        private System.Windows.Forms.CheckBox temp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox fanControl;
        private System.Windows.Forms.CheckBox flow;
        private System.Windows.Forms.CheckBox fanRpm;
        private System.Windows.Forms.CheckBox load;
        private System.Windows.Forms.CheckBox voltage;
        private System.Windows.Forms.CheckBox clock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox misc;
        private System.Windows.Forms.CheckBox power;
        private System.Windows.Forms.CheckBox network;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox factor;
        private System.Windows.Forms.Button about;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox battery;
        private System.Windows.Forms.CheckBox psu;
    }
}