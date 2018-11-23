using Neurotec.Licensing;
using Neurotec.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTS.SiCEP.Biometria.Huellas
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            const int Port = 5000;
            const string Address = "/local";
            const string Components = "Biometrics.FingerExtraction,Devices.FingerScanners,Biometrics.FaceExtraction,Biometrics.FaceDetection,Devices.Cameras,Biometrics.IrisExtraction,Biometrics.IrisSegmentation,Devices.IrisScanners,Media,Devices.Microphones,Biometrics.VoiceExtraction";

            try
            {
                foreach (string component in Components.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    NLicense.ObtainComponents(Address, Port, component);
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new BuscarHuella(args));
                Application.Run(new MainForm(args));
            }
            catch (Exception ex)
            {
                Utils.ShowException(ex);
            }
        }
    }
}
