
namespace LibreHardwareMonitorAfterburnerPlugin
{
    partial class AboutDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
            this.projectLink = new System.Windows.Forms.LinkLabel();
            this.license = new System.Windows.Forms.LinkLabel();
            this.info = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ok = new System.Windows.Forms.Button();
            this.libraryLink = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // projectLink
            // 
            this.projectLink.AutoSize = true;
            this.projectLink.Location = new System.Drawing.Point(82, 109);
            this.projectLink.Name = "projectLink";
            this.projectLink.Size = new System.Drawing.Size(110, 13);
            this.projectLink.TabIndex = 0;
            this.projectLink.TabStop = true;
            this.projectLink.Text = "Plugin project website";
            this.projectLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ProjectLink_LinkClicked);
            // 
            // license
            // 
            this.license.AutoSize = true;
            this.license.Location = new System.Drawing.Point(82, 87);
            this.license.Name = "license";
            this.license.Size = new System.Drawing.Size(129, 13);
            this.license.TabIndex = 1;
            this.license.TabStop = true;
            this.license.Text = "Mozilla Public License 2.0";
            this.license.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.License_LinkClicked);
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info.Location = new System.Drawing.Point(82, 12);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(280, 60);
            this.info.TabIndex = 2;
            this.info.Text = "Libre Hardware Monitor Plugin for MSI Afterburner\r\nVersion {{ver}}\r\n\r\n© 2021 Teem" +
    "u Korhonen";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // ok
            // 
            this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(346, 127);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 4;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // libraryLink
            // 
            this.libraryLink.AutoSize = true;
            this.libraryLink.Location = new System.Drawing.Point(82, 131);
            this.libraryLink.Name = "libraryLink";
            this.libraryLink.Size = new System.Drawing.Size(150, 13);
            this.libraryLink.TabIndex = 5;
            this.libraryLink.TabStop = true;
            this.libraryLink.Text = "LibreHardwareMonitor website";
            this.libraryLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LibraryLink_LinkClicked);
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 162);
            this.Controls.Add(this.libraryLink);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.info);
            this.Controls.Add(this.license);
            this.Controls.Add(this.projectLink);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About plugin";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel projectLink;
        private System.Windows.Forms.LinkLabel license;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.LinkLabel libraryLink;
    }
}