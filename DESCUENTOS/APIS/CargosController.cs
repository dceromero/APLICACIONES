using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
using System.Web.Http;
namespace DESCUENTOS.APIS
{
    public class CargosController : ApiController
    {
        LogicCargos logcargo = null;

        public string ListaDeCargos()
        {
            logcargo = new LogicCargos();
            return JsonConvert.SerializeObject(logcargo.ListadoDeCargos(), Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}
