using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
using System.Web.Http;
namespace DESCUENTOS.APIS
{
    public class EmpresasController : ApiController
    {
        LogicEmpresas logemp = null;

        [HttpPost]
        public string ListadoEmpresas()
        {
            logemp = new LogicEmpresas();
            return JsonConvert.SerializeObject(logemp.ListaDeEmpresas(), Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}
