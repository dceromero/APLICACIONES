using System.Web;
using System.Web.Http;
using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
namespace DESCUENTOS.APIS
{
    public class CencosController : ApiController
    {
        LogicCencos logcencos = null;

        public string ListadoDeCentrosCostos()
        {
            logcencos = new LogicCencos();
            return JsonConvert.SerializeObject(logcencos.ListadoDeCentroCosto());
        }
    }
}
