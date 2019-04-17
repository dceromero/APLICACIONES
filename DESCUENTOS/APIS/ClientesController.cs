using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
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

        public string ListarClientexVendedor(long id)
        {
            lgclient = new LogicClientes();
            return JsonConvert.SerializeObject(lgclient.ListarClientesXVendedor(id));
        }
    }
}
