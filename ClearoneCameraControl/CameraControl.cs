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
        private readonly HttpClient _httpClient = new();

        public CameraControl()
        {
            InitializeComponent();
            SetPresetLabels();

            TopMost = true;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YWRtaW46QVNNQ2h1cmNoNENocmlz");
            _httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            _httpClient.DefaultRequestHeaders.Add("Referer", $"http://{Settings.Default.CameraDnsName}/menu_mini.html");
            _httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
        }

        private void SetPresetLabels()
        {
            FormHelper.SetupPresetButton(Preset1Button, Preset1MenuItem, Settings.Default.Preset1Name);
            FormHelper.SetupPresetButton(Preset2Button, Preset2MenuItem, Settings.Default.Preset2Name);
            FormHelper.SetupPresetButton(Preset3Button, Preset3MenuItem, Settings.Default.Preset3Name);
            FormHelper.SetupPresetButton(Preset4Button, Preset4MenuItem, Settings.Default.Preset4Name);
        }

        private void PresetButton_Click(object sender, EventArgs e)
        {
            switch (sender)
            {
                case Button button:
                    CallCameraPreset(Convert.ToInt32(button.Tag), button.Text);
                    break;
                case ToolStripMenuItem { Visible: true } menuItem:
                    CallCameraPreset(Convert.ToInt32(menuItem.Tag), menuItem.Text);
                    break;
            }
        }

        private void CallCameraPreset(int presetNumber, string presetName)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var result = _httpClient.GetAsync($"http://{Settings.Default.CameraDnsName}/cgi-bin/ptzctrl.cgi?ptzcmd&poscall&{presetNumber}")?.Result;

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

        private void LoadPreviewStream()
        {
            CameraMoveStatus.Text = "Loading camera preview...";
            CameraPreview.Audio.IsMute = true;
            CameraPreview.Play($"rtsp://{Settings.Default.CameraDnsName}:554/{Settings.Default.CameraStreamQuality}");
            CameraPreview.EncounteredError += CameraPreview_EncounteredError;
            CameraPreview.Playing += CameraPreview_OnPlaying;
            CameraPreview.Stopped += CameraPreview_Stopped;
        }

        private void CameraPreview_Stopped(object sender, Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs e)
        {
            HandleError("Video Preview has stopped");
            CameraMoveStatus.Text = "WARNING: Video preview has stopped";
        }

        private void CameraPreview_Buffering(object sender, Vlc.DotNet.Core.VlcMediaPlayerBufferingEventArgs e)
        {
            HandleError("Video Preview is buffering");
            CameraMoveStatus.Text = "WARNING: Video preview is buffering";
        }

        private void CameraPreview_OnPlaying(object sender, Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs e)
        {
            CameraMoveStatus.Text = "";

            CameraPreview.Buffering -= CameraPreview_Buffering;
            CameraPreview.Buffering += CameraPreview_Buffering;
        }

        private void CameraPreview_EncounteredError(object sender, Vlc.DotNet.Core.VlcMediaPlayerEncounteredErrorEventArgs e)
        {
            HandleError("Video Preview Error");
            CameraMoveStatus.Text = "ERROR: Video preview failed to load";
        }

        private void ConfigurationMenuItem_Click(object sender, EventArgs e)
        {
            using var configurationEditor = new ConfigurationEditor();
            configurationEditor.ShowDialog();
        }

        private void CameraPreview_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            e.VlcLibDirectory = new DirectoryInfo(Settings.Default.VLCInstallPath);
        }

        private void CameraControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CameraPreview.IsPlaying)
            {
                CameraPreview.Stop();
            }

            _httpClient?.Dispose();
        }
    }
}
