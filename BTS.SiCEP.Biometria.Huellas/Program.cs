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
            var licenciasNoActivadas = string.Empty;
            const int Port = 5000;
            const string Address = "/local";
            const string Components = "Biometrics.FingerExtraction,Devices.FingerScanners,Biometrics.FaceExtraction,Biometrics.FaceDetection,Devices.Cameras,Biometrics.IrisExtraction,Biometrics.IrisSegmentation,Devices.IrisScanners,Media,Devices.Microphones,Biometrics.VoiceExtraction";


            foreach (string component in Components.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                try
                {
                    NLicense.ObtainComponents(Address, Port, component);
                }
                catch (Exception ex)
                {
                    licenciasNoActivadas += component + ", ";                    
                }
            }

            if (licenciasNoActivadas.Length>0)
            {
                MessageBox.Show(string.Format("Los siguientes componentes, no se logro activar licencia: {0}", licenciasNoActivadas),"Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(args));

        }
    }
}
