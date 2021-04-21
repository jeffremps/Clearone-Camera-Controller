
namespace ClearoneCameraControl
{
    partial class CameraControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraControl));
            this.Preset1Button = new System.Windows.Forms.Button();
            this.Preset2Button = new System.Windows.Forms.Button();
            this.Preset3Button = new System.Windows.Forms.Button();
            this.CameraStatus = new System.Windows.Forms.StatusStrip();
            this.CameraMoveStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.CameraPreview = new Vlc.DotNet.Forms.VlcControl();
            this.Preset4Button = new System.Windows.Forms.Button();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigurationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PresetsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Preset1MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Preset2MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Preset3MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Preset4MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraPreview)).BeginInit();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Preset1Button
            // 
            this.Preset1Button.Location = new System.Drawing.Point(12, 27);
            this.Preset1Button.Name = "Preset1Button";
            this.Preset1Button.Size = new System.Drawing.Size(127, 23);
            this.Preset1Button.TabIndex = 0;
            this.Preset1Button.Tag = "1";
            this.Preset1Button.Text = "Preset 1";
            this.Preset1Button.UseVisualStyleBackColor = true;
            this.Preset1Button.Click += new System.EventHandler(this.PresetButton_Click);
            // 
            // Preset2Button
            // 
            this.Preset2Button.Location = new System.Drawing.Point(145, 27);
            this.Preset2Button.Name = "Preset2Button";
            this.Preset2Button.Size = new System.Drawing.Size(127, 23);
            this.Preset2Button.TabIndex = 2;
            this.Preset2Button.Tag = "2";
            this.Preset2Button.Text = "Preset 2";
            this.Preset2Button.UseVisualStyleBackColor = true;
            this.Preset2Button.Click += new System.EventHandler(this.PresetButton_Click);
            // 
            // Preset3Button
            // 
            this.Preset3Button.Location = new System.Drawing.Point(12, 56);
            this.Preset3Button.Name = "Preset3Button";
            this.Preset3Button.Size = new System.Drawing.Size(127, 23);
            this.Preset3Button.TabIndex = 3;
            this.Preset3Button.Tag = "3";
            this.Preset3Button.Text = "Preset 3";
            this.Preset3Button.UseVisualStyleBackColor = true;
            this.Preset3Button.Click += new System.EventHandler(this.PresetButton_Click);
            // 
            // CameraStatus
            // 
            this.CameraStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CameraStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CameraMoveStatus});
            this.CameraStatus.Location = new System.Drawing.Point(0, 239);
            this.CameraStatus.Name = "CameraStatus";
            this.CameraStatus.Size = new System.Drawing.Size(284, 22);
            this.CameraStatus.TabIndex = 4;
            this.CameraStatus.Text = " ";
            // 
            // CameraMoveStatus
            // 
            this.CameraMoveStatus.Name = "CameraMoveStatus";
            this.CameraMoveStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // CameraPreview
            // 
            this.CameraPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraPreview.BackColor = System.Drawing.Color.Black;
            this.CameraPreview.Location = new System.Drawing.Point(12, 85);
            this.CameraPreview.Name = "CameraPreview";
            this.CameraPreview.Size = new System.Drawing.Size(260, 146);
            this.CameraPreview.Spu = -1;
            this.CameraPreview.TabIndex = 5;
            this.CameraPreview.Text = "vlcControl1";
            this.CameraPreview.VlcLibDirectory = null;
            this.CameraPreview.VlcMediaplayerOptions = null;
            this.CameraPreview.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.CameraPreview_VlcLibDirectoryNeeded);
            // 
            // Preset4Button
            // 
            this.Preset4Button.Location = new System.Drawing.Point(145, 56);
            this.Preset4Button.Name = "Preset4Button";
            this.Preset4Button.Size = new System.Drawing.Size(127, 23);
            this.Preset4Button.TabIndex = 6;
            this.Preset4Button.Tag = "4";
            this.Preset4Button.Text = "Preset 4";
            this.Preset4Button.UseVisualStyleBackColor = true;
            this.Preset4Button.Click += new System.EventHandler(this.PresetButton_Click);
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.PresetsMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(284, 24);
            this.Menu.TabIndex = 7;
            this.Menu.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConfigurationMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileMenuItem.Text = "File";
            // 
            // ConfigurationMenuItem
            // 
            this.ConfigurationMenuItem.Name = "ConfigurationMenuItem";
            this.ConfigurationMenuItem.Size = new System.Drawing.Size(148, 22);
            this.ConfigurationMenuItem.Text = "Configuration";
            this.ConfigurationMenuItem.Click += new System.EventHandler(this.ConfigurationMenuItem_Click);
            // 
            // PresetsMenuItem
            // 
            this.PresetsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Preset1MenuItem,
            this.Preset2MenuItem,
            this.Preset3MenuItem,
            this.Preset4MenuItem});
            this.PresetsMenuItem.Name = "PresetsMenuItem";
            this.PresetsMenuItem.Size = new System.Drawing.Size(56, 20);
            this.PresetsMenuItem.Text = "Presets";
            // 
            // Preset1MenuItem
            // 
            this.Preset1MenuItem.Name = "Preset1MenuItem";
            this.Preset1MenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.Preset1MenuItem.Size = new System.Drawing.Size(134, 22);
            this.Preset1MenuItem.Tag = "1";
            this.Preset1MenuItem.Text = "Preset 1";
            this.Preset1MenuItem.Click += new System.EventHandler(this.PresetButton_Click);
            // 
            // Preset2MenuItem
            // 
            this.Preset2MenuItem.Name = "Preset2MenuItem";
            this.Preset2MenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.Preset2MenuItem.Size = new System.Drawing.Size(134, 22);
            this.Preset2MenuItem.Tag = "2";
            this.Preset2MenuItem.Text = "Preset 2";
            this.Preset2MenuItem.Click += new System.EventHandler(this.PresetButton_Click);
            // 
            // Preset3MenuItem
            // 
            this.Preset3MenuItem.Name = "Preset3MenuItem";
            this.Preset3MenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.Preset3MenuItem.Size = new System.Drawing.Size(134, 22);
            this.Preset3MenuItem.Tag = "3";
            this.Preset3MenuItem.Text = "Preset 3";
            this.Preset3MenuItem.Click += new System.EventHandler(this.PresetButton_Click);
            // 
            // Preset4MenuItem
            // 
            this.Preset4MenuItem.Name = "Preset4MenuItem";
            this.Preset4MenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.Preset4MenuItem.Size = new System.Drawing.Size(134, 22);
            this.Preset4MenuItem.Tag = "4";
            this.Preset4MenuItem.Text = "Preset 4";
            this.Preset4MenuItem.Click += new System.EventHandler(this.PresetButton_Click);
            // 
            // CameraControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Preset4Button);
            this.Controls.Add(this.CameraPreview);
            this.Controls.Add(this.CameraStatus);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.Preset3Button);
            this.Controls.Add(this.Preset2Button);
            this.Controls.Add(this.Preset1Button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(1066, 250);
            this.MainMenuStrip = this.Menu;
            this.Name = "CameraControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Camera Control";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CameraControl_FormClosing);
            this.Shown += new System.EventHandler(this.CameraControl_Shown);
            this.CameraStatus.ResumeLayout(false);
            this.CameraStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraPreview)).EndInit();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Preset1Button;
        private System.Windows.Forms.Button Preset2Button;
        private System.Windows.Forms.Button Preset3Button;
        private System.Windows.Forms.StatusStrip CameraStatus;
        private System.Windows.Forms.ToolStripStatusLabel CameraMoveStatus;
        private Vlc.DotNet.Forms.VlcControl CameraPreview;
        private System.Windows.Forms.Button Preset4Button;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConfigurationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PresetsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Preset1MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Preset2MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Preset3MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Preset4MenuItem;
    }
}

