using BTS.SICEP.Biometria.Entidades;
using Neurotec.Biometrics;
using Neurotec.Licensing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SICEP.WCF.BiometriaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BiometriaServicio" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BiometriaServicio.svc or BiometriaServicio.svc.cs at the Solution Explorer and start debugging.
    public class BiometriaServicio : IBiometriaServicio
    {
        public BiometriaServicio()
        {
            ActivarLicenciaNT();
        }

        public async Task<PersonaInfo> BuscarHuella(string imagenBase64, int idBusqueda)
        {
            #region BuscarHuella
            var finger = new NFinger();
            var subject = new NSubject();
            var buscador = new BiometriaBuscador();

            try
            {
                var template = Convert.FromBase64String(imagenBase64);
                finger.SampleBuffer = new Neurotec.IO.NBuffer(template);
                subject.Fingers.Add(finger);

                var result = await buscador.BuscarHuellaEnTemplates(subject, idBusqueda);

                return result.PersonaIdentificar;
            }
            catch (Exception ex)
            {
                Utils.LogEvent(ex.Message);
                throw;
            }
            #endregion
        }

        public async Task<PersonaInfo> BuscarFacial(string imagenBase64, int idBusqueda)
        {
            #region BuscarHuella
            var face = new NFace();
            var subject = new NSubject();
            var buscador = new BiometriaBuscador();

            try
            {
                var template = Convert.FromBase64String(imagenBase64);
                face.SampleBuffer = new Neurotec.IO.NBuffer(template);
                subject.Faces.Add(face);

                var result = await buscador.BuscarFacialEnTemplates(subject, idBusqueda);

                return result.PersonaIdentificar;
            }
            catch (Exception ex)
            {
                Utils.LogEvent(ex.Message);
                throw;
            }
            #endregion
        }

        public async Task<PersonaInfo> BuscarIris(string imagenBase64, int idBusqueda, short ojo)
        {
            #region BuscarHuella
            var iris = new NIris();
            var subject = new NSubject();
            var buscador = new BiometriaBuscador();

            try
            {
                var template = Convert.FromBase64String(imagenBase64);
                iris.SampleBuffer = new Neurotec.IO.NBuffer(template);
                subject.Irises.Add(iris);

                var result = await buscador.BuscarIrisEnTemplates(subject, idBusqueda, ojo);

                return result.PersonaIdentificar;
            }
            catch (Exception ex)
            {
                Utils.LogEvent(ex.Message);
                throw;
            }
            #endregion
        }

        public async Task<PersonaInfo> BuscarVoz(string vozBase64, int idBusqueda)
        {
            #region BuscarHuella
            var voice = new NVoice();
            var subject = new NSubject();
            var buscador = new BiometriaBuscador();

            try
            {
                var template = Convert.FromBase64String(vozBase64);
                voice.SampleBuffer = new Neurotec.IO.NBuffer(template);
                subject.Voices.Add(voice);

                var result = await buscador.BuscarFacialEnTemplates(subject, idBusqueda);

                return result.PersonaIdentificar;
            }
            catch (Exception ex)
            {
                Utils.LogEvent(ex.Message);
                throw;
            }
            #endregion
        }

        private void ActivarLicenciaNT()
        {
            const int Port = 5000;
            const string Address = "/local";
            const string Components = "Biometrics.FingerExtraction,Biometrics.FingerMatching,Biometrics.FaceExtraction,Biometrics.FaceMatching,Biometrics.IrisExtraction,Biometrics.IrisMatching";

            try
            {
                foreach (string component in Components.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    NLicense.ObtainComponents(Address, Port, component);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
