using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
using System.Web.Http;

namespace DESCUENTOS.APIS
{
    public class OficinasController : ApiController
    {
        LogicOficinas logOfi = null;
        [HttpPost]
        public string ListadoOfixReg(string id)
        {
            logOfi = new LogicOficinas();
            return JsonConvert.SerializeObject(logOfi.ListadoOfixReg(id));
        }
    }
}
