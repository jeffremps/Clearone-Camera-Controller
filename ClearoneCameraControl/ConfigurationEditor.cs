using System;
using System.Windows.Forms;
using ClearoneCameraControl.Properties;

namespace ClearoneCameraControl
{
    public partial class ConfigurationEditor : Form
    {
        public ConfigurationEditor()
        {
            InitializeComponent();
        }

        private void ConfigurationEditor_Load(object sender, EventArgs e)
        {
            CameraNameInput.Text = Settings.Default.CameraDnsName;
            Preset1Input.Text = Settings.Default.Preset1Name;
            Preset2Input.Text = Settings.Default.Preset2Name;
            Preset3Input.Text = Settings.Default.Preset3Name;
            Preset4Input.Text = Settings.Default.Preset4Name;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Settings.Default.CameraDnsName = CameraNameInput.Text;
            Settings.Default.Preset1Name = Preset1Input.Text;
            Settings.Default.Preset2Name = Preset2Input.Text;
            Settings.Default.Preset3Name = Preset3Input.Text;
            Settings.Default.Preset4Name = Preset4Input.Text;

            Settings.Default.Save();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
