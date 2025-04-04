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
            components = new System.ComponentModel.Container();
            ok = new Button();
            cancel = new Button();
            sensorGroupSelections = new GroupBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            mainboard = new CheckBox();
            hardwareFlagsSource = new BindingSource(components);
            cpu = new CheckBox();
            ram = new CheckBox();
            gpu = new CheckBox();
            fancontroller = new CheckBox();
            hdd = new CheckBox();
            network = new CheckBox();
            battery = new CheckBox();
            psu = new CheckBox();
            sensorFilters = new GroupBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            temp = new CheckBox();
            sensorFlagsSource = new BindingSource(components);
            fanRpm = new CheckBox();
            fanControl = new CheckBox();
            clock = new CheckBox();
            factor = new CheckBox();
            voltage = new CheckBox();
            power = new CheckBox();
            load = new CheckBox();
            flow = new CheckBox();
            misc = new CheckBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            about = new Button();
            panel1 = new Panel();
            sensorGroupSelections.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)hardwareFlagsSource).BeginInit();
            sensorFilters.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sensorFlagsSource).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ok
            // 
            ok.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ok.DialogResult = DialogResult.OK;
            ok.Location = new Point(435, 0);
            ok.Name = "ok";
            ok.Size = new Size(75, 23);
            ok.TabIndex = 1;
            ok.Text = "Save";
            ok.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancel.DialogResult = DialogResult.Cancel;
            cancel.Location = new Point(516, 0);
            cancel.Name = "cancel";
            cancel.Size = new Size(75, 23);
            cancel.TabIndex = 2;
            cancel.Text = "Cancel";
            cancel.UseVisualStyleBackColor = true;
            // 
            // sensorGroupSelections
            // 
            sensorGroupSelections.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sensorGroupSelections.Controls.Add(flowLayoutPanel3);
            sensorGroupSelections.Location = new Point(3, 57);
            sensorGroupSelections.Name = "sensorGroupSelections";
            sensorGroupSelections.Size = new Size(292, 293);
            sensorGroupSelections.TabIndex = 4;
            sensorGroupSelections.TabStop = false;
            sensorGroupSelections.Text = "Active hardware groups";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(mainboard);
            flowLayoutPanel3.Controls.Add(cpu);
            flowLayoutPanel3.Controls.Add(ram);
            flowLayoutPanel3.Controls.Add(gpu);
            flowLayoutPanel3.Controls.Add(fancontroller);
            flowLayoutPanel3.Controls.Add(hdd);
            flowLayoutPanel3.Controls.Add(network);
            flowLayoutPanel3.Controls.Add(battery);
            flowLayoutPanel3.Controls.Add(psu);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel3.Location = new Point(3, 16);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(286, 274);
            flowLayoutPanel3.TabIndex = 7;
            // 
            // mainboard
            // 
            mainboard.AutoSize = true;
            mainboard.DataBindings.Add(new Binding("Checked", hardwareFlagsSource, "MainboardEnabled", true));
            mainboard.Location = new Point(3, 3);
            mainboard.Name = "mainboard";
            mainboard.Size = new Size(76, 17);
            mainboard.TabIndex = 0;
            mainboard.Text = "Mainboard";
            mainboard.UseVisualStyleBackColor = true;
            // 
            // hardwareFlagsSource
            // 
            hardwareFlagsSource.DataSource = typeof(HardwareFlags);
            // 
            // cpu
            // 
            cpu.AutoSize = true;
            cpu.DataBindings.Add(new Binding("Checked", hardwareFlagsSource, "CpuEnabled", true));
            cpu.Location = new Point(3, 26);
            cpu.Name = "cpu";
            cpu.Size = new Size(78, 17);
            cpu.TabIndex = 1;
            cpu.Text = "Processors";
            cpu.UseVisualStyleBackColor = true;
            // 
            // ram
            // 
            ram.AutoSize = true;
            ram.DataBindings.Add(new Binding("Checked", hardwareFlagsSource, "RamEnabled", true));
            ram.Location = new Point(3, 49);
            ram.Name = "ram";
            ram.Size = new Size(63, 17);
            ram.TabIndex = 2;
            ram.Text = "Memory";
            ram.UseVisualStyleBackColor = true;
            // 
            // gpu
            // 
            gpu.AutoSize = true;
            gpu.DataBindings.Add(new Binding("Checked", hardwareFlagsSource, "GpuEnabled", true));
            gpu.Location = new Point(3, 72);
            gpu.Name = "gpu";
            gpu.Size = new Size(54, 17);
            gpu.TabIndex = 3;
            gpu.Text = "GPUs";
            gpu.UseVisualStyleBackColor = true;
            // 
            // fancontroller
            // 
            fancontroller.AutoSize = true;
            fancontroller.DataBindings.Add(new Binding("Checked", hardwareFlagsSource, "FanControllerEnabled", true));
            fancontroller.Location = new Point(3, 95);
            fancontroller.Name = "fancontroller";
            fancontroller.Size = new Size(95, 17);
            fancontroller.TabIndex = 4;
            fancontroller.Text = "Fan controllers";
            fancontroller.UseVisualStyleBackColor = true;
            // 
            // hdd
            // 
            hdd.AutoSize = true;
            hdd.DataBindings.Add(new Binding("Checked", hardwareFlagsSource, "HddEnabled", true));
            hdd.Location = new Point(3, 118);
            hdd.Name = "hdd";
            hdd.Size = new Size(63, 17);
            hdd.TabIndex = 5;
            hdd.Text = "Storage";
            hdd.UseVisualStyleBackColor = true;
            // 
            // network
            // 
            network.AutoSize = true;
            network.DataBindings.Add(new Binding("Checked", hardwareFlagsSource, "NetworkEnabled", true));
            network.Location = new Point(3, 141);
            network.Name = "network";
            network.Size = new Size(66, 17);
            network.TabIndex = 6;
            network.Text = "Network";
            network.UseVisualStyleBackColor = true;
            // 
            // battery
            // 
            battery.AutoSize = true;
            battery.DataBindings.Add(new Binding("Checked", hardwareFlagsSource, "BatteryEnabled", true));
            battery.Location = new Point(3, 164);
            battery.Name = "battery";
            battery.Size = new Size(59, 17);
            battery.TabIndex = 7;
            battery.Text = "Battery";
            battery.UseVisualStyleBackColor = true;
            // 
            // psu
            // 
            psu.AutoSize = true;
            psu.DataBindings.Add(new Binding("Checked", hardwareFlagsSource, "PsuEnabled", true));
            psu.Location = new Point(3, 187);
            psu.Name = "psu";
            psu.Size = new Size(48, 17);
            psu.TabIndex = 8;
            psu.Text = "PSU";
            psu.UseVisualStyleBackColor = true;
            // 
            // sensorFilters
            // 
            sensorFilters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sensorFilters.Controls.Add(flowLayoutPanel2);
            sensorFilters.Location = new Point(301, 57);
            sensorFilters.Name = "sensorFilters";
            sensorFilters.Size = new Size(293, 293);
            sensorFilters.TabIndex = 5;
            sensorFilters.TabStop = false;
            sensorFilters.Text = "Active sensor types";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(temp);
            flowLayoutPanel2.Controls.Add(fanRpm);
            flowLayoutPanel2.Controls.Add(fanControl);
            flowLayoutPanel2.Controls.Add(clock);
            flowLayoutPanel2.Controls.Add(factor);
            flowLayoutPanel2.Controls.Add(voltage);
            flowLayoutPanel2.Controls.Add(power);
            flowLayoutPanel2.Controls.Add(load);
            flowLayoutPanel2.Controls.Add(flow);
            flowLayoutPanel2.Controls.Add(misc);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(3, 16);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(287, 274);
            flowLayoutPanel2.TabIndex = 11;
            // 
            // temp
            // 
            temp.AutoSize = true;
            temp.DataBindings.Add(new Binding("Checked", sensorFlagsSource, "TemperatureEnabled", true));
            temp.Location = new Point(3, 3);
            temp.Name = "temp";
            temp.Size = new Size(106, 17);
            temp.TabIndex = 0;
            temp.Text = "Temperature (°C)";
            temp.UseVisualStyleBackColor = true;
            // 
            // sensorFlagsSource
            // 
            sensorFlagsSource.DataSource = typeof(SensorFlags);
            // 
            // fanRpm
            // 
            fanRpm.AutoSize = true;
            fanRpm.DataBindings.Add(new Binding("Checked", sensorFlagsSource, "FanSpeedEnabled", true));
            fanRpm.Location = new Point(3, 26);
            fanRpm.Name = "fanRpm";
            fanRpm.Size = new Size(109, 17);
            fanRpm.TabIndex = 4;
            fanRpm.Text = "Fan speed (RPM)";
            fanRpm.UseVisualStyleBackColor = true;
            // 
            // fanControl
            // 
            fanControl.AutoSize = true;
            fanControl.DataBindings.Add(new Binding("Checked", sensorFlagsSource, "ControlEnabled", true));
            fanControl.Location = new Point(3, 49);
            fanControl.Name = "fanControl";
            fanControl.Size = new Size(93, 17);
            fanControl.TabIndex = 6;
            fanControl.Text = "Fan speed (%)";
            fanControl.UseVisualStyleBackColor = true;
            // 
            // clock
            // 
            clock.AutoSize = true;
            clock.DataBindings.Add(new Binding("Checked", sensorFlagsSource, "ClockEnabled", true));
            clock.Location = new Point(3, 72);
            clock.Name = "clock";
            clock.Size = new Size(105, 17);
            clock.TabIndex = 1;
            clock.Text = "Frequency (Mhz)";
            clock.UseVisualStyleBackColor = true;
            // 
            // factor
            // 
            factor.AutoSize = true;
            factor.DataBindings.Add(new Binding("Checked", sensorFlagsSource, "FactorEnabled", true));
            factor.Location = new Point(3, 95);
            factor.Name = "factor";
            factor.Size = new Size(72, 17);
            factor.TabIndex = 11;
            factor.Text = "Multipliers";
            factor.UseVisualStyleBackColor = true;
            // 
            // voltage
            // 
            voltage.AutoSize = true;
            voltage.DataBindings.Add(new Binding("Checked", sensorFlagsSource, "VoltageEnabled", true));
            voltage.Location = new Point(3, 118);
            voltage.Name = "voltage";
            voltage.Size = new Size(62, 17);
            voltage.TabIndex = 2;
            voltage.Text = "Voltage";
            voltage.UseVisualStyleBackColor = true;
            // 
            // power
            // 
            power.AutoSize = true;
            power.DataBindings.Add(new Binding("Checked", sensorFlagsSource, "PowerEnabled", true));
            power.Location = new Point(3, 141);
            power.Name = "power";
            power.Size = new Size(76, 17);
            power.TabIndex = 9;
            power.Text = "Power (W)";
            power.UseVisualStyleBackColor = true;
            // 
            // load
            // 
            load.AutoSize = true;
            load.DataBindings.Add(new Binding("Checked", sensorFlagsSource, "LoadEnabled", true));
            load.Location = new Point(3, 164);
            load.Name = "load";
            load.Size = new Size(67, 17);
            load.TabIndex = 3;
            load.Text = "Load (%)";
            load.UseVisualStyleBackColor = true;
            // 
            // flow
            // 
            flow.AutoSize = true;
            flow.DataBindings.Add(new Binding("Checked", sensorFlagsSource, "FlowEnabled", true));
            flow.Location = new Point(3, 187);
            flow.Name = "flow";
            flow.Size = new Size(80, 17);
            flow.TabIndex = 5;
            flow.Text = "Flow speed";
            flow.UseVisualStyleBackColor = true;
            // 
            // misc
            // 
            misc.AutoSize = true;
            misc.DataBindings.Add(new Binding("Checked", sensorFlagsSource, "MiscEnabled", true));
            misc.Location = new Point(3, 210);
            misc.Name = "misc";
            misc.Size = new Size(227, 17);
            misc.TabIndex = 10;
            misc.Text = "Misc (data sizes, network and storage info)";
            misc.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(sensorGroupSelections, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(sensorFilters, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(597, 353);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            tableLayoutPanel1.SetColumnSpan(label1, 2);
            label1.Location = new Point(3, 3);
            label1.Margin = new Padding(3, 3, 0, 10);
            label1.Name = "label1";
            label1.Size = new Size(594, 41);
            label1.TabIndex = 6;
            label1.Text = "Select which hardware and sensor types to activate. What sensors are discovered will depend on the system hardware and whether it is supported by Libre Hardware Monitor.\r\n\r\n";
            // 
            // about
            // 
            about.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            about.Location = new Point(6, 0);
            about.Name = "about";
            about.Size = new Size(75, 23);
            about.TabIndex = 3;
            about.Text = "About...";
            about.UseVisualStyleBackColor = true;
            about.Click += About_Click;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(about);
            panel1.Controls.Add(ok);
            panel1.Controls.Add(cancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 353);
            panel1.Name = "panel1";
            panel1.Size = new Size(597, 26);
            panel1.TabIndex = 7;
            // 
            // SetupDialog
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 379);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SetupDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Libre Hardware Monitor Plug-in Setup";
            sensorGroupSelections.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)hardwareFlagsSource).EndInit();
            sensorFilters.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sensorFlagsSource).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.BindingSource hardwareFlagsSource;
        private System.Windows.Forms.BindingSource sensorFlagsSource;
    }
}