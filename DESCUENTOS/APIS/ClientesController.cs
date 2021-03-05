using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
using System.Web.Http;
namespace DESCUENTOS.APIS
{
    public class ClientesController : ApiController
    {
        LogicClientes lgclient = null;

        public string ListarClientexVendedor()
        {
            var id = System.Web.HttpContext.Current.Session["id"];
            if (id != null)
            {
                lgclient = new LogicClientes();
                return JsonConvert.SerializeObject(lgclient.ListarClientesXVendedor(long.Parse(id.ToString())));
            }
            else
            {
                return string.Empty;
            }
        }

        [HttpGet]
        public string ListarClientexVendedor(long id)
        {
            lgclient = new LogicClientes();
            return JsonConvert.SerializeObject(lgclient.ListarClientesXVendedor(id));

        }


        public string DetalledelCliente(long id)
        {
            lgclient = new LogicClientes();
            return JsonConvert.SerializeObject(lgclient.DETALLECLIENTE(id));
        }


    }
}
