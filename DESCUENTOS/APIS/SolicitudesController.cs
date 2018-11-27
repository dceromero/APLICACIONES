using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using DataEntitysAplicaciones.DataEntitysDescuentos;
using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
namespace DESCUENTOS.APIS
{
    public class SolicitudesController : ApiController
    {
        LogicSolicitudes lgsolict = null;

        [HttpPost]
        public string ListarTiposSolicitudes()
        {
            lgsolict = new LogicSolicitudes();
            return JsonConvert.SerializeObject(lgsolict.ListarTiposSolicitudes());
        }


        [HttpPost]
        public string ListarEncabezados()
        {
            var id = HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            lgsolict = new LogicSolicitudes();
            return JsonConvert.SerializeObject(lgsolict.ListadoEncabezados(cc));
        }

        [HttpPost]
        public string Encabezados(long id)
        {
            lgsolict = new LogicSolicitudes();
            return JsonConvert.SerializeObject(lgsolict.Encabezados(id));
        }

        [HttpPost]
        public async Task<string> Guadarsolicitud(MCDESCUENTOS headerDescuentos)
        {
            lgsolict = new LogicSolicitudes();
            var result = await lgsolict.GuadarSolicitudDescuento(headerDescuentos);
            return JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public async Task<string> ActualizarSolicitud(List<MDDESCUENTO> mc)
        {
            var id = HttpContext.Current.Session["id"];
           long cc = long.Parse(id.ToString());
            lgsolict = new LogicSolicitudes();
            var result = await  lgsolict.ActualizarMD(mc, cc);
            return JsonConvert.SerializeObject(result);
        }


        public string ListadoInforme() {
            lgsolict = new LogicSolicitudes();
            return JsonConvert.SerializeObject(lgsolict.EncabezadoInforme());
        }

        public string ExportExcel(long id)
        {
            lgsolict = new LogicSolicitudes();
            return JsonConvert.SerializeObject(lgsolict.ExportarExcel(id));
        }

    }
}
