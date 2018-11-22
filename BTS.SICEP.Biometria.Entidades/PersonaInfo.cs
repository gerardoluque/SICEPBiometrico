using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SICEP.Biometria.Entidades
{
    public class PersonaInfo
    {
        public int id;
        public short estado;
        public short municipio;
        public string cereso;
        public short ano;
        public long folio;
        public short num_ingreso;
        public bool Identificado { get; set; }

    }
}
