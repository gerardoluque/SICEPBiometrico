using Neurotec.Licensing;
using Neurotec.Samples;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTS.SiCEP.Biometria.Huellas
{
    static class Program
    {
        static string appGuid = "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            using (Mutex mutex = new Mutex(false, appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Ya se encuentra la ventana de busqueda de biometria abierta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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

                if (licenciasNoActivadas.Length > 0)
                {
                    MessageBox.Show(string.Format("Los siguientes componentes, no se logro activar licencia: {0}", licenciasNoActivadas), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm(args));
            }
        }

        /// 
        /// check if given exe alread running or not
        /// 
        /// returns true if already running
        private static bool IsAlreadyRunning()
        {
            string strLoc = Assembly.GetExecutingAssembly().Location;
            FileSystemInfo fileInfo = new FileInfo(strLoc);
            string exeName = fileInfo.Name;
            bool createdNew;

            Mutex mutex = new Mutex(true, "Global\\" + exeName, out createdNew);
            if (createdNew)
                mutex.ReleaseMutex();

            return !createdNew;
        }
    }
}
