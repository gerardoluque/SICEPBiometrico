using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SiCEP.Biometria.Huellas.Entidades
{
    public class VerificarHuellaInfo
    {
        public PersonaInfo PersonaIdentificar { get; set; }
        public string Dedo { get; set; }
        public string Completo { get; set; }
        public string Servicename { get; set; }

        public bool Capturado { get; set; }
        public bool Identificado { get; set; }
    }
}
