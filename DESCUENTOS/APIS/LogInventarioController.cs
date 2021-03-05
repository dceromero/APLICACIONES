using DataEntitysAplicaciones.DataEntitysDescuentos;
using DataLogicAplicaciones.DataLogicsDescuentos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DESCUENTOS.APIS
{
    public class LogInventarioController : ApiController
    {

        public HttpResponseMessage Archivos()
        {
            AI_DOCSAP docSap = new AI_DOCSAP();
            AI_MOVCABAJUSTE aiCab = new AI_MOVCABAJUSTE();
            LogicAInventarios lgAI = new LogicAInventarios();
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            var id = HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var docsap = httpRequest.Form["docsap"];
                    var fecinv = httpRequest.Form["fecinv"];
                    var justifi = httpRequest.Form["justifi"];
                    var codcentro = httpRequest.Form["codcentro"];
                    var cantsku = httpRequest.Form["cantsku"];
                    var valtotalinv = httpRequest.Form["valtotalinv"];

                    aiCab.CEDULASUPRV = cc;
                    aiCab.DOCUMENSAP = docsap;
                    aiCab.FECINV = DateTime.Parse(fecinv);
                    aiCab.OBSERVACION = justifi;
                    aiCab.CODCENTRO = codcentro;
                    aiCab.CANTSKU = double.Parse(cantsku);
                    aiCab.VALTOTALINV = double.Parse(valtotalinv);

                    var namefile = httpRequest.Form["name"];
                    var postedFile = httpRequest.Files[file];
                    string ruta = $"~/ArchivosSap/{namefile.TrimStart(' ')}";
                    var filePath = HttpContext.Current.Server.MapPath(ruta);
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);
                    docSap.DOCSAP = docsap;
                    docSap.NAMEFILE = namefile.TrimStart(' ');
                    lgAI.saveDocument(docSap, aiCab);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }

        [HttpPost]
        public List<VIEW_AI> listAprobacion()
        {
            var id = HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            LogicAInventarios lgAI = new LogicAInventarios();
            return lgAI.listAprobacion(cc);
        }

        [HttpPost]
        public VIEW_AI viewAprobacion(long id)
        {
            LogicAInventarios lgAI = new LogicAInventarios();
            return lgAI.viewAprobacion(id);
        }

        [HttpPost]
        public MensajeAI AprobacionAI(AI_MOVCABAJUSTE aicab)
        {

            var id = HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            aicab.CEDULASUPRV = cc;
            LogicAInventarios lgAI = new LogicAInventarios();
            return lgAI.aprobAI(aicab);
        }

        [HttpPost]
        public MensajeAI AprobacionAIMax(List<AI_MOVCABAJUSTE> aicab)
        {

            var id = HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            LogicAInventarios lgAI = new LogicAInventarios();
            return lgAI.aprobAI(aicab, cc);
        }


        [HttpGet]
        public List<CENTRO> listCentro()
        {
            LogicAInventarios lgAi = new LogicAInventarios();
            return lgAi.listcentros();
        }


        [HttpPost]
        public List<AI_MOVCABAJUSTE> listStateSup()
        {
            var id = HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            LogicAInventarios lgAI = new LogicAInventarios();
            return lgAI.listStateSup(cc);
        }

        [HttpPost]
        public List<AI_MOVCABAJUSTE> listState()
        {
            LogicAInventarios lgAI = new LogicAInventarios();
            return lgAI.listState();
        }

        [HttpGet]
        public string viewPDf(long id)
        {
            LogicAInventarios lgAI = new LogicAInventarios();
            return lgAI.viewPDF(id);
        }

        [HttpGet]
        public List<AI_INFORME> listInforme(DateTime id)
        {
            LogicAInventarios lgAI = new LogicAInventarios();
            return lgAI.listInforme(id);
        }

        [HttpPost]
        public List<AI_INFORME> listInformeAcumulado(AI_MOVCABAJUSTE ai)
        {
            LogicAInventarios lgAI = new LogicAInventarios();
            return lgAI.listInforme(ai.FECINV, ai.FECING);
        }

        [HttpPost]
        public List<AI_APROBACIONMASIVA> listAprobMasiva()
        {
            var id = HttpContext.Current.Session["id"];
            long cc = long.Parse(id.ToString());
            LogicAInventarios lgAI = new LogicAInventarios();
            return lgAI.listAprobMasiva(cc);
        }

        [HttpPost]
        public string notificacion()
        {
            LogicAInventarios lgAI = new LogicAInventarios();
            return lgAI.notificacionMasiva();
        }

        [HttpPost]
        public List<VIEW_AIINFORMEESTADOS> infoState(AI_MOVCABAJUSTE ai)
        {
            LogicAInventarios lgAi = new LogicAInventarios();
            return lgAi.infoState(ai);
        }
    }
}
