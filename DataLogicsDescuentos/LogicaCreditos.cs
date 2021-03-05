using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicaCreditos
    {
        private MetodosCreditos credito;
        private MetodosEnviarEmail email;

        public async Task<string> Guardar(SOLICITUDESCUPO SolCred)
        {
            string result = "";
            try
            {
                credito = new MetodosCreditos();
                Mensajes correo = credito.GuardarCredito(SolCred);
                if (correo.id == 1)
                {
                    email = new MetodosEnviarEmail();
                    result = await email.EnviarMensajeCredito(correo.message, "Autorización");
                }
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            return result;
        }

        public List<HEADCREDITOS> ListadoAprobacion(long cedula)
        {
            credito = new MetodosCreditos();
            return credito.ListaCreditos(cedula);
        }


        public List<FILECLIENTCARTERA> ListaArchivos(FILECLIENTCARTERA arc) {
            credito = new MetodosCreditos();
            return credito.saveFile(arc);
        }

        public View_SOLICITUDESCUPO VistaAprobacion(long id)
        {
            try {
credito = new MetodosCreditos();
            return credito.VistaAprobacion(id);
            }catch(Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
            
        }

        public async Task<string> Aprobacion(SOLICITUDESCUPO SolCred)
        {
            string result = "";
            try
            {
                credito = new MetodosCreditos();
                email = new MetodosEnviarEmail();
                VIEW_Jefes correo = credito.Aprobaciones(SolCred);
                if (correo.CEDULA == 1111111111)
                {
                    MetodosPDFs PDFS = new MetodosPDFs();
                    result = PDFS.PDFSOLICTUDCUPO(SolCred.IDSOL);
                    FUNC_VIEW_EMAILCUPO info = credito.VistaAprobacion(SolCred.IDSOL, 0);
                    await email.NotificarCartera(info);
                }
                else
                {
                    string aprob = SolCred.APROBJF == 2 ? "Autorización" : "Rechazado";
                    FUNC_VIEW_EMAILCUPO info = credito.VistaAprobacion(SolCred.IDSOL, SolCred.CEDULA);
                    result = await email.EnviarMensajeCredito(correo.MAIL, aprob, info);
                }
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            return result;
        }


        public async Task<string> Notificacion(long id) {
            credito = new MetodosCreditos();
            VIEW_Jefes correo = credito.Notificaciones(id);
            email = new MetodosEnviarEmail();
            FUNC_VIEW_EMAILCUPO info = credito.VistaAprobacion(id, 0);
            return await email.EnviarMensajeCredito(correo.MAIL, "Notificación", info);
        }

        public string PDFCredito(long id)
        {
            MetodosPDFs pdf = new MetodosPDFs();
            return pdf.PDFSOLICTUDCUPO(id);
        }

        public List<VIEW_INFORMECARTERA> InformeGeneralCT(short id)
        {
            credito = new MetodosCreditos();
            string buscar = "ESTADO=";
            switch (id)
            {
                case -1:
                    buscar = $"{buscar} '-1'";
                    break;
                case 0:
                    buscar = $"{buscar} '5' and NOTI=0";
                    break;
                default:
                    buscar = $"{buscar} '5' and NOTI=1";
                    break;
            }
            return credito.InformeGeneral(buscar);
        }
    }
}
