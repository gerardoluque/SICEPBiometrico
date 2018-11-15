using BTS.SICEP.Biometria.Entidades;
using Neurotec.Biometrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SICEP.WCF.BiometriaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBiometriaServicio" in both code and config file together.
    [ServiceContract]
    public interface IBiometriaServicio
    {
        [OperationContract]
        Task<PersonaInfo> BuscarHuella(string imagenBase64, int idBusqueda);
        [OperationContract]
        Task<PersonaInfo> BuscarFacial(string imagenBase64, int idBusqueda);
        [OperationContract]
        Task<PersonaInfo> BuscarIris(string imagenBase64, int idBusqueda, short ojo);
        [OperationContract]
        Task<PersonaInfo> BuscarVoz(string vozBase64, int idBusqueda);

    }
}
