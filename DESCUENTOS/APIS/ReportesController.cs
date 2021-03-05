using DataEntitysAplicaciones.DataEntitysDescuentos;
using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Http;
namespace DESCUENTOS.APIS
{
    public class ReportesController : ApiController
    {
        LogicReportes lgrept = null;

        [HttpPost]
        public string DetalleSolicitud(DateTime fecini, DateTime fecfin)
        {
            lgrept = new LogicReportes();
            string result = JsonConvert.SerializeObject(lgrept.DetalleSolicitud(fecini, fecfin));
            return result;
        }

        [HttpPost]
        public string ExportExcel(MCDESCUENTOS fechas)
        {
            LogicSolicitudes lgsolict = new LogicSolicitudes();
            return JsonConvert.SerializeObject(lgsolict.ExportarExcel(fechas));
        }

        [HttpPost]
        public string InformeVendedor(MCDESCUENTOS reporte)
        {
            var id = HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            if (cc != 0)
            {
                reporte.CEDULA = cc;
                lgrept = new LogicReportes();
                string result = JsonConvert.SerializeObject(lgrept.InformeVendedor(reporte));
                return result;
            }
            else
            {
                return null;
            }
        }

    }
}
