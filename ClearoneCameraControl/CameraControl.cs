using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using ClearoneCameraControl.Helpers;
using ClearoneCameraControl.Properties;

namespace ClearoneCameraControl
{
    public partial class CameraControl : Form
    {
        private readonly HttpClient httpClient = new HttpClient();

        public CameraControl()
        {
            InitializeComponent();
            SetPresetLabels();

            TopMost = true;

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YWRtaW46QVNNQ2h1cmNoNENocmlz");
            httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpClient.DefaultRequestHeaders.Add("Referer", $"http://{Settings.Default.CameraDnsName}/menu_mini.html");
            httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
        }

        private void SetPresetLabels()
        {
            FormHelper.SetupPresetButton(Preset1Button, Settings.Default.Preset1Name);
            FormHelper.SetupPresetButton(Preset2Button, Settings.Default.Preset2Name);
            FormHelper.SetupPresetButton(Preset3Button, Settings.Default.Preset3Name);
            FormHelper.SetupPresetButton(Preset4Button, Settings.Default.Preset4Name);
        }

        private void PresetButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            CallCameraPreset(Convert.ToInt32(button.Tag), button.Text);
        }

        private void CallCameraPreset(int presetNumber, string presetName)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var result = httpClient.GetAsync($"http://{Settings.Default.CameraDnsName}/cgi-bin/ptzctrl.cgi?ptzcmd&poscall&{presetNumber}")?.Result;

                if (result.IsSuccessStatusCode)
                {
                    CameraMoveStatus.Text = $"SUCCESS: Camera moved to \"{presetName}\"";
                }
                else
                {
                    CameraMoveStatus.Text = $"ERROR: Failed to move to \"{presetName}\"";
                    HandleError($"{result.StatusCode} - {result.ReasonPhrase}");
                    HandleError(result?.Content?.ReadAsStringAsync()?.Result);
                }
            }
            catch (Exception ex)
            {
                CameraMoveStatus.Text = $"ERROR: Failed to move to \"{presetName}\"";
                HandleError(ex.ToString());
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void HandleError(string error)
        {
            File.AppendAllLines("Log.txt", new string[] { $"{DateTime.Now.ToFileTime()} - {error}" });
        }

        private void CameraControl_Shown(object sender, EventArgs e)
        {
            LoadPreviewStream();
        }

        private void LoadCameraPreviewButton_Click(object sender, EventArgs e)
        {
            LoadPreviewStream();
        }

        private void LoadPreviewStream()
        {
            CameraMoveStatus.Text = $"Loading camera preview...";
            CameraPreview.Play($"rtsp://{Settings.Default.CameraDnsName}:554/2");
            CameraPreview.Audio.IsMute = true;
            CameraPreview.EncounteredError += CameraPreview_EncounteredError;
            CameraPreview.Playing += CameraPreview_OnPlaying;
            CameraPreview.Buffering += CameraPreview_Buffering;
            CameraPreview.Stopped += CameraPreview_Stopped;
        }

        private void CameraPreview_Stopped(object sender, Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs e)
        {
            HandleError("Video Preview has stopped");
            CameraMoveStatus.Text = $"WARNING: Video preview has stopped";
        }

        private void CameraPreview_Buffering(object sender, Vlc.DotNet.Core.VlcMediaPlayerBufferingEventArgs e)
        {
            HandleError("Video Preview is buffering");
            CameraMoveStatus.Text = $"WARNING: Video preview is buffering";
        }

        private void CameraPreview_OnPlaying(object sender, Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs e)
        {
            CameraMoveStatus.Text = "";
        }

        private void CameraPreview_EncounteredError(object sender, Vlc.DotNet.Core.VlcMediaPlayerEncounteredErrorEventArgs e)
        {
            HandleError("Video Preview Error");
            CameraMoveStatus.Text = $"ERROR: Video preview failed to load";
        }

        private void ConfigurationMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
