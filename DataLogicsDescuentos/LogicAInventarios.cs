using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicAInventarios
    {
        private MetodosAInventarios mtAI;

        private List<AI_MOVDETAJUSTE> dataExcel(DataExcel data, long id)
        {
            List<AI_MOVDETAJUSTE> listdet = new List<AI_MOVDETAJUSTE>();

            for (int i = 2; i <= 1000; i++)
            {
                if (data.RecibirCelda(1, i, 1).ToString() == "0")
                {
                    break;
                }
                var aiDet = new AI_MOVDETAJUSTE();
                aiDet.ID_MOVCABAJ = id;
                aiDet.CODPRODUCTO = data.RecibirCelda(1, i, 3).ToString();
                aiDet.DESCRIPCION = data.RecibirCelda(1, i, 4).ToString();
                aiDet.LOTE = data.RecibirCelda(1, i, 5).ToString();
                aiDet.BODEGA = data.RecibirCelda(1, i, 7).ToString();
                aiDet.UNDMED = data.RecibirCelda(1, i, 11).ToString();
                aiDet.CANTIDAD = double.Parse(data.RecibirCelda(1, i, 9).ToString());
                aiDet.CANTTEORICA = double.Parse(data.RecibirCelda(1, i, 8).ToString());
                aiDet.VALOR = double.Parse(data.RecibirCelda(1, i, 14).ToString());
                aiDet.VALORNEG = double.Parse(data.RecibirCelda(1, i, 13).ToString());
                aiDet.JUSTIFICACION = data.RecibirCelda(1, i, 15).ToString();
                aiDet.AJUSTAR = data.RecibirCelda(1, i, 16).ToString();
                listdet.Add(aiDet);


            }
            return listdet;
        }
        public void saveDocument(AI_DOCSAP sapDoc, AI_MOVCABAJUSTE ai)
        {
            try
            {

                mtAI = new MetodosAInventarios();
                mtAI.saveDocument(sapDoc);
                string ruta = $"~/ArchivosSap/{sapDoc.NAMEFILE}";
                var filePath = HttpContext.Current.Server.MapPath(ruta);
                if (!filePath.ToLower().Contains("pdf"))
                {

                    var aiCab = mtAI.saveAICab(ai);
                    var data = new DataExcel(filePath);
                    data.OpenConection();
                    foreach (var dato in dataExcel(data, aiCab.ID))
                    {
                        mtAI.saveAIDet(dato);
                    }
                    data.ClosedConection();
                    data.Dispose();
                    var mtsend = new MetodosEnviarEmail();
                    ai.ID_MOVCABAJ = aiCab.ID;
                    var jfcd = mtAI.jefeAndCD(ai);
                    var jf = aiCab.JEFE.Split('-');
                    mtsend.EnviarMensajeInventario(jf[0], jfcd.CD);
                }
            }
            catch (Exception ex)
            {
                var errors = new ERRORES();
                errors.FECHA = DateTime.Now;
                errors.LINEADELERROR = 0;
                errors.PRODUJOERROR = "saveDocument";
                errors.MENSAJE = ex.Message.ToString();
                MetodosErrores.GuardarError(errors);
            }


        }

        public List<VIEW_AI> listAprobacion(long cedula)
        {
            mtAI = new MetodosAInventarios();
            return mtAI.listaAprobacion(cedula);
        }

        public VIEW_AI viewAprobacion(long id)
        {
            mtAI = new MetodosAInventarios();
            VIEW_AI aiview = mtAI.AiCab(id);
            aiview.detAI = mtAI.AiDet(id);
            aiview.listDocSap = mtAI.aiDocPDF(aiview.DOCUMENSAP);
            return aiview;
        }

        public string viewPDF(long id)
        {
            mtAI = new MetodosAInventarios();
            VIEW_AI aiview = mtAI.AiCab(id);
            aiview.detAI = mtAI.AiDet(id);
            var pdfs = new MetodosPDFs();
            return pdfs.PDFInventario(aiview);
        }

        public List<CENTRO> listcentros()
        {
            mtAI = new MetodosAInventarios();
            return mtAI.listadoCentros();
        }

        public MensajeAI aprobAI(AI_MOVCABAJUSTE aicab)
        {
            mtAI = new MetodosAInventarios();
            var jfcd = mtAI.jefeAndCD(aicab);
            MetodosEnviarEmail send = new MetodosEnviarEmail();
            var jf = jfcd.jf.Split('-');
            send.EnviarMensajeInventario(jf[0], jfcd.CD);
            return mtAI.aprobAICab(aicab);
        }


        public MensajeAI aprobAI(List<AI_MOVCABAJUSTE> aicabs, long cc)
        {
            mtAI = new MetodosAInventarios();
            int cont = 1;
            MensajeAI result = null;
            foreach (var aicab in aicabs)
            {
                if (cont == 1)
                {
                    aicab.CEDULASUPRV = cc;
                    result = mtAI.aprobAICab(aicab);
                    var jfcd = mtAI.jefeAndCD(aicab);
                    MetodosEnviarEmail send = new MetodosEnviarEmail();
                    var jf = jfcd.jf.Split('-');
                    send.EnviarMensajeInventario(jf[0], jfcd.CD);
                }
                else
                {
                    aicab.CEDULASUPRV = cc;
                    result = mtAI.aprobAICab(aicab);
                }
                cont++;
            }
            return result;
        }

        public List<AI_MOVCABAJUSTE> listStateSup(long codSup)
        {
            mtAI = new MetodosAInventarios();
            return mtAI.listStateSup(codSup);
        }

        public List<AI_MOVCABAJUSTE> listState()
        {
            mtAI = new MetodosAInventarios();
            return mtAI.listState();
        }

        public List<AI_INFORME> listInforme(DateTime fecha)
        {
            mtAI = new MetodosAInventarios();
            return mtAI.aiInforme(fecha);
        }

        public List<AI_INFORME> listInforme(DateTime fecha, DateTime hasta)
        {
            mtAI = new MetodosAInventarios();
            return mtAI.aiInforme(fecha, hasta);
        }

        public List<AI_APROBACIONMASIVA> listAprobMasiva(long id)
        {
            mtAI = new MetodosAInventarios();
            return mtAI.aiListAprobMasiva(id);
        }

        public string notificacionMasiva()
        {
            MetodosEnviarEmail sendmail = new MetodosEnviarEmail();
            mtAI = new MetodosAInventarios();
            var mail = mtAI.actualizarContabilidad();
            foreach (var sup in mail)
            {
                sendmail.EnviarMensajeContabilidad(sup.JEFE);
            }
            return "Se ha enviado la notificacíon";
        }

        public List<VIEW_AIINFORMEESTADOS> infoState(AI_MOVCABAJUSTE ai)
        {
            mtAI = new MetodosAInventarios();
            return mtAI.informState(ai);
        }
    }
}
