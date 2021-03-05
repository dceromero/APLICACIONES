using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosAInventarios
    {
        private ModelAplicacionesDescuentos dbContext;

        public void saveDocument(AI_DOCSAP docSap)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"insert into AI_DOCSAP values('{docSap.DOCSAP}', '{docSap.NAMEFILE}')";
            dbContext.Database.ExecuteSqlCommand(tsql);
        }

        public MensajeAI saveAICab(AI_MOVCABAJUSTE ai)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"EXEC GUARDARAI '{ai.FECINV.ToString("yyyy-MM-dd")}','{ai.CODCENTRO}', '{ai.CEDULASUPRV}', '{ai.DOCUMENSAP}', '{ai.OBSERVACION}', '{ai.CANTSKU}', '{ai.VALTOTALINV}' ";
            return dbContext.Database.SqlQuery<MensajeAI>(tsql).FirstOrDefault();
        }

        public void saveAIDet(AI_MOVDETAJUSTE ai)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"insert into AI_MOVDETAJUSTE values('{ai.ID_MOVCABAJ}', '{ai.CODPRODUCTO}', '{ai.DESCRIPCION}', '{ai.BODEGA}', '{ai.UNDMED}', '{ai.CANTIDAD.ToString().Replace(",", ".")}', '{ai.VALOR.ToString().Replace(",", ".")}', '{ai.JUSTIFICACION}', '{ai.CANTTEORICA.ToString().Replace(",", ".")}', '{ai.LOTE}', '{ai.VALORNEG.ToString().Replace(",",".")}', '{ai.AJUSTAR}')";
            dbContext.Database.SqlQuery<MensajeAI>(tsql).FirstOrDefault();
        }

        public List<VIEW_AI> listaAprobacion(long cedula)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"exec Proc_AIbUSQUEDAAPROBADOR '{cedula}'";
            return dbContext.Database.SqlQuery<VIEW_AI>(tsql).ToList();
        }

        public VIEW_AI AiCab(long id)
        {

            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"Select * from VIEW_AI where  ID_MOVCABAJ = '{id}'";
            return dbContext.Database.SqlQuery<VIEW_AI>(tsql).FirstOrDefault();
        }

        public List<VIEW_AIDet> AiDet(long id)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"Select * from VIEW_AIDet where  ID_MOVCABAJ = '{id}'";
            return dbContext.Database.SqlQuery<VIEW_AIDet>(tsql).ToList();
        }

        public MensajeAI aprobAICab(AI_MOVCABAJUSTE ai)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"EXEC AI_ACTUALIZAR '{ai.ID_MOVCABAJ}' , '{ai.CEDULASUPRV}', '{ai.APROBGRFI}' ";
            return dbContext.Database.SqlQuery<MensajeAI>(tsql).FirstOrDefault();
        }

        public List<CENTRO> listadoCentros()
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = "select CODCENTRO, CONCAT(CODCENTRO, '-', NOMBRE) AS NOMBRE, ID_REGIONAL from centro";
            return dbContext.Database.SqlQuery<CENTRO>(tsql).ToList();
        }

        public List<AI_MOVCABAJUSTE> listStateSup(long codSup)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from AI_MOVCABAJUSTE where CEDULASUPRV = {codSup}";
            return dbContext.Database.SqlQuery<AI_MOVCABAJUSTE>(tsql).ToList();
        }

        public List<AI_MOVCABAJUSTE> listState()
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from AI_MOVCABAJUSTE  WHERE GENERADO =0 order by FECING ";
            return dbContext.Database.SqlQuery<AI_MOVCABAJUSTE>(tsql).ToList();
        }

        public List<MensajeAI> actualizarContabilidad()
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = "exec AI_Notificacion";
            return dbContext.Database.SqlQuery<MensajeAI>(tsql).ToList();
        }

        public List<VIEW_FIRMAS_CREDITOS> firmas(long id)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from VIEW_AIFIRMAS where ID_MOVCABAJ = {id}";
            return dbContext.Database.SqlQuery<VIEW_FIRMAS_CREDITOS>(tsql).ToList();
        }

        public List<AI_INFORME> aiInforme(DateTime fecha)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = "select * from AI_INFORME " +
                $"where  YEAR(fecinv) = '{fecha.Year}' and MONTH(fecinv)='{fecha.Month}' ";
            return dbContext.Database.SqlQuery<AI_INFORME>(tsql).ToList();
        }

        public List<AI_INFORME> aiInforme(DateTime fecha, DateTime hasta)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = "select * from AI_INFORME " +
                $"where  (YEAR(fecinv) between '{fecha.Year}' and '{hasta.Year}') and (MONTH(fecinv) between '{fecha.Month}'  and '{hasta.Month}')";
            return dbContext.Database.SqlQuery<AI_INFORME>(tsql).ToList();
        }

        public List<AI_APROBACIONMASIVA> aiListAprobMasiva(long id)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"exec Proc_AIAPROBMAS'{id}'";
            return dbContext.Database.SqlQuery<AI_APROBACIONMASIVA>(tsql).ToList();
        }

        public List<AI_DOCSAP> aiDocPDF(string docsap)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"Select * from AI_DOCSAP where  DOCSAP='{docsap}' and NAMEFILE like '%pdf%' ";
            return dbContext.Database.SqlQuery<AI_DOCSAP>(tsql).ToList();
        }

        public jfCD jefeAndCD(AI_MOVCABAJUSTE ai)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql1 = $"Select 'j.rodriguez@gloria.com.co-Javier Rodriguez'as jf, dbo.CENTRODISTRIBUICION('{ai.ID_MOVCABAJ}') as CD";
            string tsql = $"Select dbo.Func_AIMailJefe('{ai.CEDULASUPRV}') as jf, dbo.CENTRODISTRIBUICION('{ai.ID_MOVCABAJ}') as CD";
            string transa = ai.CEDULASUPRV == 30329396 ? tsql1 : tsql;
            return dbContext.Database.SqlQuery<jfCD>(transa).FirstOrDefault();
        }

        public List<VIEW_AIINFORMEESTADOS> informState(AI_MOVCABAJUSTE ai)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from VIEW_AIINFORMEESTADOS " +
                $"where  (YEAR(fecinv) between '{ai.FECINV.Year}' and '{ai.FECING.Year}') and (MONTH(fecinv) between '{ai.FECINV.Month}'  and '{ai.FECING.Month}')";
            return dbContext.Database.SqlQuery<VIEW_AIINFORMEESTADOS>(tsql).ToList();
        }
    }
}


public class jfCD
{
    public string jf { get; set; }
    public string CD { get; set; }
}