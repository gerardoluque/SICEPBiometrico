using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SiCEP.Biometria.Huellas.Entidades
{
    public class BusquedaResultadoInfo
    {
        public VerificarHuellaInfo Verificacion { get; set; }
        public bool ConError { get; set; }
        public string MensajeError { get; set; }
    }
}
