using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
using System.Web.Http;

namespace DESCUENTOS.APIS
{
    public class RegionalesController : ApiController
    {
        LogicRegionales logreg = null;

        public string ListadoRegionales()
        {
            logreg = new LogicRegionales();
            return JsonConvert.SerializeObject(logreg.ListadoRegionales());
        }
    }
}
