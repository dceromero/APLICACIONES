using DataEntitysAplicaciones.DataEntitysDescuentos;
using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
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
        public string Download(long id)
        {
            lgsolict = new LogicSolicitudes();
            lgsolict.ActualizarDonwLoad(id, 1);
            return "oki";
        }

        [HttpPost]
        public async Task<string> Guadarsolicitud(MCDESCUENTOS headerDescuentos)
        {
            lgsolict = new LogicSolicitudes();
            var id = HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            if (cc != 0)
            {
                headerDescuentos.CEDULA = cc;
                var result = await lgsolict.GuadarSolicitudDescuento(headerDescuentos);
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                return null;
            }

        }

        [HttpPost]
        public async Task<string> ActualizarSolicitud(List<MDDESCUENTO> mc)
        {
            var id = HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            lgsolict = new LogicSolicitudes();
            var result = await lgsolict.ActualizarMD(mc, cc);
            return JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string ActualizarMasivo(List<MDDESCUENTO> mc)
        {
            var id = HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            lgsolict = new LogicSolicitudes();
            var result = lgsolict.ActualizarMasivo(mc, cc);
            return JsonConvert.SerializeObject(result);
        }


        public string ListadoInforme()
        {
            lgsolict = new LogicSolicitudes();
            return JsonConvert.SerializeObject(lgsolict.EncabezadoInforme());
        }


        public string ExportExcel(long id)
        {
            lgsolict = new LogicSolicitudes();
            return JsonConvert.SerializeObject(lgsolict.ExportarExcel(id));
        }

        public string ListaTrade()
        {
            lgsolict = new LogicSolicitudes();
            return JsonConvert.SerializeObject(lgsolict.listaTrade());
        }

        [HttpPost]
        public string listaDescuentos(MCDESCUENTOS mc)
        {
            var id = HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            mc.CEDULA = cc;
            lgsolict = new LogicSolicitudes();
            return JsonConvert.SerializeObject(lgsolict.listaDescuentos(mc));
        }

        [HttpPost]
        public string detalleDescuentos(MCDESCUENTOS mc)
        {
            var id = HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            mc.CEDULA = cc;
            lgsolict = new LogicSolicitudes();
            return JsonConvert.SerializeObject(lgsolict.DetalleDescuentos(mc));
        }

        [HttpGet]
        public List<REPAADMONVENTAS> detailtDiscount(long id)
        {
            var mc = new MCDESCUENTOS();
            mc.FECING = DateTime.Now;
            mc.FECFIN = DateTime.Now;
            mc.CEDULA = id;
            lgsolict = new LogicSolicitudes();
            return lgsolict.DetalleDescuentos(mc);
        }

        [HttpPost]
        public string detalleConsolidado(MCDESCUENTOS mc)
        {
            lgsolict = new LogicSolicitudes();
            return JsonConvert.SerializeObject(lgsolict.DetalleConsolidado(mc));
        }

    }
}
