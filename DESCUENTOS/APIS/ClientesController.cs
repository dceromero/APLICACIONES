using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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

        public string DetalledelCliente(long id)
        {
            lgclient = new LogicClientes();
            return JsonConvert.SerializeObject(lgclient.DETALLECLIENTE(id));
        }


        public HttpResponseMessage Prueba()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var namefile = httpRequest.Form["name"];
                    var postedFile = httpRequest.Files[file];
                    string ruta = $"~/ExcelCartera/{namefile.TrimStart(' ')}";
                    var filePath = HttpContext.Current.Server.MapPath(ruta);
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }
    }
}
