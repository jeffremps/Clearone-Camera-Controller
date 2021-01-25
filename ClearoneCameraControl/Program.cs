using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClearoneCameraControl
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new CameraControl());
            }
            catch(Exception ex)
            {
                File.AppendAllLines("Log.txt", new string[] { $"{DateTime.Now.ToFileTime()} - {ex}" });
            }
        }
    }
}
