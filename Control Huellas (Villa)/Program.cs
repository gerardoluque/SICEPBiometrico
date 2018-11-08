using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ControlDeHuellas
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length <= 0)
                return;

            switch (args[0])
            {
                case "1": //enrolar
                    Application.Run(new capturaHuella(args));
                    break;
                case "2": //valida
                    Application.Run(new validaHuella(args));
                    break;
            
            }
        }
    }
}
