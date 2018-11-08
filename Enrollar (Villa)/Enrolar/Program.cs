using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Enrolar
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

            if (args.GetLength(0) == 0)
            {
                MessageBox.Show("Favor de proporcionar los argumentos");
                return;
            }

            Application.Run(new Form1(args));
        }
    }
}
