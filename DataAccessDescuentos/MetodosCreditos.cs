using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosCreditos
    {
        private ModelAplicacionesDescuentos dbcontext;

        public Mensajes GuardarCredito(SOLICITUDESCUPO sol)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"exec InsertarCupoCredito '{sol.TIPOSOL}', '{sol.CODCLIENTE}', '{sol.CEDULA}', '{sol.CUPOSOLICITADO.ToString().Replace(",",".")}', '{sol.VIGENCIA.ToString("yyyy-MM-dd")}' , '{sol.OBS}' ";
            var result = dbcontext.Database.SqlQuery<Mensajes>(tsql).FirstOrDefault();
            return result;
        }

        public List<FILECLIENTCARTERA> saveFile(FILECLIENTCARTERA archivo)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"exec GuardarArchivoCartera '{archivo.codcliente}', '{archivo.namefile}'";
            var result = dbcontext.Database.SqlQuery<FILECLIENTCARTERA>(tsql).ToList();
            return result;
        }

        public List<HEADCREDITOS> ListaCreditos(long cedula)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"PROC_VISTA_CREDITOS '{cedula}'";
            var result = dbcontext.Database.SqlQuery<HEADCREDITOS>(tsql).ToList();
            return result;
        }

        public VIEW_Jefes Aprobaciones(SOLICITUDESCUPO cupo)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"exec APROBACION_CREDITO '{cupo.APROBJF}', '{cupo.CEDULA}', '{cupo.IDSOL}', '{cupo.CUPOAPROBADO}', '{cupo.OBS}', '{cupo.CUPODISPONIBLE}', '{cupo.CUPOVENCIDO}', '{cupo.CUPOENCARTERA}', '{cupo.DIASVEN}', '{cupo.hipoteca}', '{cupo.pignoracion}'";
            var result = dbcontext.Database.SqlQuery<VIEW_Jefes>(tsql).FirstOrDefault();
            return result;
        }

        public VIEW_Jefes Notificaciones(long id)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"exec PROC_NOTIFICAR_CUPO '{id}'";
            var result = dbcontext.Database.SqlQuery<VIEW_Jefes>(tsql).FirstOrDefault();
            return result;
        }

        public View_SOLICITUDESCUPO VistaAprobacion(long id)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from View_SOLICITUDESCUPO where idsol='{id}'";
            var result = dbcontext.Database.SqlQuery<View_SOLICITUDESCUPO>(tsql).FirstOrDefault();
            return result;
        }

        public FUNC_VIEW_EMAILCUPO VistaAprobacion(long id, long cedula)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from FUNC_VIEW_EMAILCUPO('{id}', '{cedula}')";
            var result = dbcontext.Database.SqlQuery<FUNC_VIEW_EMAILCUPO>(tsql).FirstOrDefault();
            return result;
        }

        public List<VIEW_FIRMAS_CREDITOS> ListaFirma(long id)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from VIEW_FIRMAS_CREDITOS where idsol='{id}' ORDER BY FECAPROB  ";
            var result = dbcontext.Database.SqlQuery<VIEW_FIRMAS_CREDITOS>(tsql).ToList();
            return result;
        }

        public List<VIEW_INFORMECARTERA> InformeGeneral(string valorbuscar)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from VIEW_INFORMECARTERA where {valorbuscar}";
            var result = dbcontext.Database.SqlQuery<VIEW_INFORMECARTERA>(tsql).ToList();
            return result;
        }

    }
}
