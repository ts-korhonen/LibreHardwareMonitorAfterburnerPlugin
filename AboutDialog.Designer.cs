
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
            projectLink = new LinkLabel();
            license = new LinkLabel();
            info = new Label();
            pictureBox1 = new PictureBox();
            ok = new Button();
            libraryLink = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // projectLink
            // 
            projectLink.AutoSize = true;
            projectLink.Location = new Point(82, 109);
            projectLink.Name = "projectLink";
            projectLink.Size = new Size(110, 13);
            projectLink.TabIndex = 0;
            projectLink.TabStop = true;
            projectLink.Text = "Plugin project website";
            projectLink.LinkClicked += ProjectLink_LinkClicked;
            // 
            // license
            // 
            license.AutoSize = true;
            license.Location = new Point(82, 87);
            license.Name = "license";
            license.Size = new Size(129, 13);
            license.TabIndex = 1;
            license.TabStop = true;
            license.Text = "Mozilla Public License 2.0";
            license.LinkClicked += License_LinkClicked;
            // 
            // info
            // 
            info.AutoSize = true;
            info.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            info.Location = new Point(82, 12);
            info.Name = "info";
            info.Size = new Size(280, 60);
            info.TabIndex = 2;
            info.Text = "Libre Hardware Monitor Plugin for MSI Afterburner\r\nVersion {{ver}}\r\n\r\n© Teemu Korhonen";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 59);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // ok
            // 
            ok.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ok.DialogResult = DialogResult.OK;
            ok.Location = new Point(346, 127);
            ok.Name = "ok";
            ok.Size = new Size(75, 23);
            ok.TabIndex = 4;
            ok.Text = "OK";
            ok.UseVisualStyleBackColor = true;
            // 
            // libraryLink
            // 
            libraryLink.AutoSize = true;
            libraryLink.Location = new Point(82, 131);
            libraryLink.Name = "libraryLink";
            libraryLink.Size = new Size(150, 13);
            libraryLink.TabIndex = 5;
            libraryLink.TabStop = true;
            libraryLink.Text = "LibreHardwareMonitor website";
            libraryLink.LinkClicked += LibraryLink_LinkClicked;
            // 
            // AboutDialog
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(433, 162);
            Controls.Add(libraryLink);
            Controls.Add(ok);
            Controls.Add(pictureBox1);
            Controls.Add(info);
            Controls.Add(license);
            Controls.Add(projectLink);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutDialog";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "About plugin";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

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