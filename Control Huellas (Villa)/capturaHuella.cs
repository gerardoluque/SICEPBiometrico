using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using enrolamiento;
using System.Data.SqlClient;

namespace ControlDeHuellas
{
    public partial class capturaHuella : Form
    {
        string[] param;

        public capturaHuella(string[] args)
        {
            InitializeComponent();
            param = args;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            captura.id = param[1];
            captura.estado = param[2];
            captura.municipio = param[3];
            captura.cereso = param[4];
            captura.ano = param[5];
            captura.folio = param[6];
            captura.dedo = param[7];
            captura.completo = param[8];
            captura.servicename = param[9];
            captura.Inicializar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            #region btnAceptar_Click
            string cadena = "";
            if (captura.enrolado == true)
            {
                cadena = captura.ObtenerTemplate();
                captura.RegistraHuella();
                Application.Exit();
            }
            else
            {
                captura.Mensaje("No ha capturado huella.");
            }
            #endregion
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            captura.Finalizar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
