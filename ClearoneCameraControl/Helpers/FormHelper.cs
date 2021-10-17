using System.Windows.Forms;

namespace ClearoneCameraControl.Helpers
{
    public static class FormHelper
    {
        public static void SetupPresetButton(Button button, string presetName)
        {
            if (!string.IsNullOrWhiteSpace(presetName))
            {
                button.Text = presetName;
            }
            else
            {
                button.Visible = false;
            }
        }
    }
}
