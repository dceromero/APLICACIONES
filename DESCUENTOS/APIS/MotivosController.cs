using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
using System.Web.Http;

namespace DESCUENTOS.APIS
{
    public class MotivosController : ApiController
    {
        LogicMotivos lgmot = null;

        [HttpPost]
        public string MotivosDesc()
        {
            lgmot = new LogicMotivos();
            string result = JsonConvert.SerializeObject(lgmot.MostrarMotivos());
            return result;
        }

    }
}
