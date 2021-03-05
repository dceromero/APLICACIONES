using DataEntitysAplicaciones.DataEntitysDescuentos;
using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace DESCUENTOS.APIS
{
    public class CarteraController : ApiController
    {
        LogicaCreditos logCredito = null;

        [HttpPost]
        public async Task<string> Guadarsolicitud(SOLICITUDESCUPO CupoCredito)
        {
            logCredito = new LogicaCreditos();
            var id = HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            if (cc != 0)
            {
                CupoCredito.CEDULA = cc;
                var result = await logCredito.Guardar(CupoCredito);
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                return null;
            }
        }
        [HttpPost]
        public string ListadoXAprobar()
        {
            logCredito = new LogicaCreditos();
            var id = HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            if (cc != 0)
            {
                var result = logCredito.ListadoAprobacion(cc);
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                return null;
            }
        }


        [HttpPost]
        public async Task<string> aprobacionsolicitud(SOLICITUDESCUPO CupoCredito)
        {
            logCredito = new LogicaCreditos();
            var id = HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            if (cc != 0)
            {
                CupoCredito.CEDULA = cc;
                var result = await logCredito.Aprobacion(CupoCredito);
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public string VistaAprobacion(long id)
        {
            logCredito = new LogicaCreditos();
            var idu = HttpContext.Current.Session["id"];
            long cc = long.Parse(idu.ToString());
            if (cc != 0)
            {
                var result = logCredito.VistaAprobacion(id);
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public string InformeGeneral(short id)
        {
            logCredito = new LogicaCreditos();
            var idu = HttpContext.Current.Session["id"];
            long cc = long.Parse(idu.ToString());
            if (cc != 0)
            {
                var result = logCredito.InformeGeneralCT(id);
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public string Download(short id)
        {
            logCredito = new LogicaCreditos();
            var idu = HttpContext.Current.Session["id"];
            long cc = long.Parse(idu.ToString());
            if (cc != 0)
            {
                var result = logCredito.PDFCredito(id);
                return result;
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public async Task<string> Notificacion(short id)
        {
            logCredito = new LogicaCreditos();
            var idu = HttpContext.Current.Session["id"];
            long cc = long.Parse(idu.ToString());
            if (cc != 0)
            {
                var result = logCredito.Notificacion(id);
                return await result;
            }
            else
            {
                return null;
            }
        }


        public HttpResponseMessage Prueba(long id)
        {

            LogicaCreditos creditos = new LogicaCreditos();
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    FILECLIENTCARTERA fileCartera = new FILECLIENTCARTERA();
                    fileCartera.codcliente = id;
                    var namefile = httpRequest.Form["name"];
                    var postedFile = httpRequest.Files[file];
                    string ruta = $"~/ExcelCartera/{namefile.TrimStart(' ')}";
                    var filePath = HttpContext.Current.Server.MapPath(ruta);
                    postedFile.SaveAs(filePath);
                    fileCartera.namefile = namefile;
                    creditos.ListaArchivos(fileCartera);
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
