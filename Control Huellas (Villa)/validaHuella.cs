using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlDeHuellas
{
    public partial class validaHuella : Form
    {
        string[] param;

        public validaHuella(string[] args)
        {
            param = args;
            InitializeComponent();
        }

        private void validaHuella_Load(object sender, EventArgs e)
        {
            verifica.id = param[1];
            verifica.estado = param[2];
            verifica.municipio = param[3];
            verifica.cereso = param[4];
            verifica.ano = param[5];
            verifica.folio = param[6];
            verifica.dedo = param[7];
            verifica.completo = param[8];
            verifica.servicename = param[9];
            verifica.Inicializar();
            verifica.CargaComboDedos();
        }
    }
}
