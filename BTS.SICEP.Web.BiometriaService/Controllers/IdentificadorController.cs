using Neurotec.Biometrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BTS.SICEP.Web.BiometriaService.Controllers
{
    public class IdentificadorController : ApiController
    {
        // GET: api/Identificador
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Identificador/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Identificador
        [HttpPost]
        public async Task<IHttpActionResult> Huella([FromBody]string subject)
        {
            try
            {
                return Ok("Hola biometria");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT: api/Identificador/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Identificador/5
        public void Delete(int id)
        {
        }
    }
}
