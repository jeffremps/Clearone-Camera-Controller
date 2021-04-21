using System.Windows.Forms;

namespace ClearoneCameraControl.Helpers
{
    public static class FormHelper
    {
        public static void SetupPresetButton(Button button, ToolStripMenuItem menuItem, string presetName)
        {
            if (!string.IsNullOrWhiteSpace(presetName))
            {
                button.Text = presetName;
                menuItem.Text = presetName;
            }
            else
            {
                button.Visible = false;
                menuItem.Visible = false;
            }
        }
    }
}
