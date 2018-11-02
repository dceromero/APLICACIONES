using System.Web;
using System.Web.Http;
using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
namespace DESCUENTOS.APIS
{
    public class EmpresasController : ApiController
    {
        LogicEmpresas logemp = null;

        [HttpPost]
        public string ListadoEmpresas()
        {
            logemp = new LogicEmpresas();
            return JsonConvert.SerializeObject(logemp.ListaDeEmpresas());
        }
    }
}
