using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLogicAplicaciones.DataLogicsDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;
using System.Web;

namespace DESCUENTOS.APIS
{
    public class LegalizacionController : ApiController
    {

        private LogicLegalizacion lgLegalizacion = null;

        [HttpGet]
        public void eliminar(long id)
        {
            lgLegalizacion = new LogicLegalizacion();
            lgLegalizacion.eliminarMDLegalizacion(id);
        }

        [HttpPost]
        public void guardar(TRADE_MDLEGALIZACION md)
        {
            lgLegalizacion = new LogicLegalizacion();
            lgLegalizacion.guardarMDLegalizacion(md);
        }

        public void guardarDocumentos()
        {
            lgLegalizacion = new LogicLegalizacion();
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {

                var ID_LEGALIZA = httpRequest.Form["ID_LEGALIZA"];

                foreach (string file in httpRequest.Files)
                {
                    TRADE_DOCUMENTOS doc = new TRADE_DOCUMENTOS();
                    doc.ID_LEGALIZA = long.Parse(ID_LEGALIZA);
                    doc.NOMBRE_ARCHIVO = httpRequest.Form["name"].ToString().Trim();
                    var postedFile = httpRequest.Files[file];
                    string ruta = $"~/ArchivoLegalizacion/{doc.NOMBRE_ARCHIVO}";
                    var filePath = HttpContext.Current.Server.MapPath(ruta);
                    postedFile.SaveAs(filePath);
                    lgLegalizacion.saveDocumento(doc);
                }
            }
        }

        public void actualizarNprov(TRADE_LEGALIZACION leg)
        {
            lgLegalizacion = new LogicLegalizacion();
            lgLegalizacion.actualizarNProv(leg.ID_LEGALIZA, leg.NRO_PROV);
        }
        public void actualizarRprov(TRADE_LEGALIZACION leg)
        {
            lgLegalizacion = new LogicLegalizacion();
            lgLegalizacion.actualizarRProv(leg.ID_LEGALIZA, leg.NRO_PROV);
        }
        public void actualizarNSap(TRADE_LEGALIZACION leg)
        {
            lgLegalizacion = new LogicLegalizacion();
            lgLegalizacion.actualizarNSap(leg.ID_LEGALIZA, leg.NRO_PROV);
        }
        [HttpGet]
        public List<PLANILLANOTACOMERCIAL> plantillaLegalizacion()
        {
            lgLegalizacion = new LogicLegalizacion();
            return lgLegalizacion.plantillaLegalzacion();
        }

        public void actualizarPlanitilla()
        {
            lgLegalizacion = new LogicLegalizacion();
            lgLegalizacion.actualizarPlanilla();
        }
        [HttpGet]
        public List<TRADE_MDLEGALIZACION> detailMDLegaliza(long id)
        {
            lgLegalizacion = new LogicLegalizacion();
            return lgLegalizacion.detailLegalizacion(id);
        }

        public void actualizarPlanRProv()
        {
            lgLegalizacion = new LogicLegalizacion();
            lgLegalizacion.actualizarPlanRProv();
        }
        public void actualizarPlanProv()
        {
            lgLegalizacion = new LogicLegalizacion();
            lgLegalizacion.actualizarPlanProv();
        }
    }
}
