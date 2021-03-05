using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
using System.Web.Http;

namespace DESCUENTOS.APIS
{
    public class GrupoClientesController : ApiController
    {
        LogicGrupoClientes logGrpClient = null;

        [HttpPost]
        public string ListaGruClient(short id)
        {
            logGrpClient = new LogicGrupoClientes();
            return JsonConvert.SerializeObject(logGrpClient.ListadoCanales(id));
        }

    }
}
