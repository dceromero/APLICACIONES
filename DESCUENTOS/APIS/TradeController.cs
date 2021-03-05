using DataEntitysAplicaciones.DataEntitysDescuentos;
using DataLogicAplicaciones.DataLogicsDescuentos;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;
using System.Web.Http;

namespace DESCUENTOS.APIS
{
    public class TradeController : ApiController
    {
        LogicTrade lgTrade;
        [HttpGet]
        public List<TRADE_VIEWCONCEPTO> listConceptos(long id)
        {
            lgTrade = new LogicTrade();
            return lgTrade.listConceptos(id);
        }

        [HttpGet]
        public List<TIPODENOTA> listNotas()
        {
            lgTrade = new LogicTrade();
            return lgTrade.listNotas();
        }

        [HttpGet]
        public List<TIPOSOLICITUD> listTipoSolicitud(short id)
        {
            lgTrade = new LogicTrade();
            return lgTrade.listTipoSolicitud(id);
        }

        [HttpPost]
        public string saveNota(TRADE_MCNOTAXPRECIO nota)
        {
            var id = System.Web.HttpContext.Current.Session["id"];
            if (id != null)
            {
                lgTrade = new LogicTrade();
                nota.CEDULA = long.Parse(id.ToString());
                return lgTrade.saveNotas(nota);
            }
            else
            {
                return string.Empty;
            }

        }

        [HttpGet]
        public List<TRADE_VIEWNOTA> listNotasComerciales()
        {
            lgTrade = new LogicTrade();
            var id = System.Web.HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            return lgTrade.listNotas(cc);
        }

        [HttpGet]
        public TRADE_VIEWNOTA notaAprobar(long id)
        {
            lgTrade = new LogicTrade();
            return lgTrade.notaAprobacion(id);
        }

        [HttpPost]
        public MensajeAI Aprobacion(TRADE_MCNOTAXPRECIO nota)
        {
            lgTrade = new LogicTrade();
            var id = System.Web.HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            nota.CEDULA = cc;
            return lgTrade.AprobacionTrade(nota);
        }

        [HttpGet]
        public List<PLANILLANOTACOMERCIAL> Planilla()
        {
            lgTrade = new LogicTrade();
            return lgTrade.planilla();
        }

        [HttpGet]
        public List<PLANILLANOTACOMERCIAL> PlanillaProv()
        {
            lgTrade = new LogicTrade();
            return lgTrade.planillaProv();
        }

        [HttpGet]
        public List<PLANILLANOTACOMERCIAL> planillaRProv()
        {
            lgTrade = new LogicTrade();
            return lgTrade.planillaRProv();
        }

        [HttpPost]
        public void ActualizarFecha()
        {
            lgTrade = new LogicTrade();
            lgTrade.ActualizarPlanilla();
        }

        [HttpGet]
        public void Eliminar(long id)
        {
            lgTrade = new LogicTrade();
            lgTrade.eliminar(id);
        }

        [HttpPost]
        public void saveDetail(TRADE_MDNOTAXPRECIO md)
        {
            lgTrade = new LogicTrade();
            lgTrade.guardarDetalle(md);
        }

        [HttpGet]
        public List<TRADE_VIEWNOTA> listEstadoNotas()
        {
            lgTrade = new LogicTrade();
            var id = System.Web.HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            return lgTrade.listNotasEstado(cc);
        }


        [HttpGet]
        public List<TRADE_VIEWNOTA> listNotasXActivacion()
        {
            lgTrade = new LogicTrade();
            var id = System.Web.HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            return lgTrade.listActivacion(cc);
        }


        [HttpGet]
        public List<TRADE_VIEWDIFPRECIOS> listLegalizacionSup()
        {
            lgTrade = new LogicTrade();
            var id = System.Web.HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            return lgTrade.listLegalizacion(cc);
        }



        [HttpPost]
        public MensajeAI aprobAdmonVenta(TRADE_MCNOTAXPRECIO nota)
        {
            lgTrade = new LogicTrade();
            var id = System.Web.HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            nota.CEDULA = cc;
            return lgTrade.AprobacionAdmonVelas(nota);
        }

        [HttpGet]
        public List<TRADE_VIEWNOTA> listAdmonVentas()
        {
            lgTrade = new LogicTrade();
            return lgTrade.listAdmonVentas();
        }

        [HttpGet]
        public List<TRADE_VIEWDIFPRECIOS> listAdmonComercial()
        {
            lgTrade = new LogicTrade();
            return lgTrade.listAdmonComercial();
        }

        [HttpPost]
        public List<TRADE_VIEWDIFPRECIOS> listAdmonComercial(TRADE_MCNOTAXPRECIO fecha)
        {
            lgTrade = new LogicTrade();
            return lgTrade.listAdmonComercial();
        }

        [HttpPost]
        public List<TRADE_INFORMEREVENEW> Informe(TRADE_MCNOTAXPRECIO nota)
        {
            lgTrade = new LogicTrade();
            return lgTrade.informeRevenew(nota);
        }

        [HttpGet]
        public List<TRADE_VIEWDIFPRECIOS> listAprobacionLegal()
        {
            lgTrade = new LogicTrade();
            var id = System.Web.HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            return lgTrade.ListAprobacionLegal(cc);
        }

        [HttpPost]
        public MensajeAI aprobLegalizacion(TRADE_MCNOTAXPRECIO nota)
        {
            lgTrade = new LogicTrade();
            var id = System.Web.HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            nota.CEDULA = cc;
            return lgTrade.AprobacionLegal(nota);
        }


        [HttpGet]
        public TRADE_VIEWDIFPRECIOS viewAprobacion(long id)
        {
            lgTrade = new LogicTrade();
            return lgTrade.viewAprobLegalizacion(id);
        }

        [HttpPost]
        public List<TRADE_VIEWINFORMESOLICITUD> informeSolicitudes(TRADE_VIEWINFORMESOLICITUD vm)
        {
            lgTrade = new LogicTrade(); var id = System.Web.HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            return lgTrade.informeSolicitudes(cc,vm);
        }
    }
}
