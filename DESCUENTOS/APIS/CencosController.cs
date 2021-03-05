using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
using System.Web.Http;
namespace DESCUENTOS.APIS
{
    public class CencosController : ApiController
    {
        LogicCencos logcencos = null;

        public string ListadoDeCentrosCostos()
        {
            logcencos = new LogicCencos();
            return JsonConvert.SerializeObject(logcencos.ListadoDeCentroCosto(), Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}
