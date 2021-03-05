using DataEntitysAplicaciones.DataEntitysDescuentos;
using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace DESCUENTOS.APIS
{
    public class CanalesController : ApiController
    {
        LogicCanales logcanales = null;

        public string ListaDeCanales()
        {
            logcanales = new LogicCanales();
            return JsonConvert.SerializeObject(logcanales.ListadoCanales());
        }

        [HttpPost]
        public async Task<string> Guadarsolicitud(MCDCTOCANAL headerDescuentos)
        {
            logcanales = new LogicCanales();
            var id = HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            if (cc != 0)
            {
                headerDescuentos.CEDULA = cc;
                var result = await logcanales.GuadarSolicitudDescuento(headerDescuentos);
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                return null;
            }

        }
        [HttpPost]
        public async Task<string> ActualizarMD(List<MDDCTOCANAL> mc)
        {
            var id = HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            logcanales = new LogicCanales();
            var result = await logcanales.ActualizarMD(mc, cc);
            return JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string ListaXAutirizar()
        {
            logcanales = new LogicCanales();
            var id = HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            if (cc != 0)
            {
                var result = logcanales.ListadoXAutorizar(cc);
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                return null;
            }

        }

        [HttpPost]
        public string EncabezadoInforme()
        {
            logcanales = new LogicCanales();
            var id = HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            if (cc != 0)
            {
                var result = logcanales.EncabezadoInforme();
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                return null;
            }

        }

        [HttpPost]
        public string Encabezado(long id)
        {
            logcanales = new LogicCanales();
            long cc = id;
            if (cc != 0)
            {
                var result = logcanales.Cabecera(cc);
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                return null;
            }

        }

        [HttpPost]
        public string DownloadExcel(long id)
        {
            LogicSolicitudes lgsolict = new LogicSolicitudes();
            lgsolict.ActualizarDonwLoad(id, 2);
            return "oki";
        }

        public string ExportExcel(long id)
        {
            logcanales = new LogicCanales();
            return JsonConvert.SerializeObject(logcanales.ExportarExcel(id));
        }
    }
}
