using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosLegalizacion
    {
        private ModelAplicacionesDescuentos dbContext = null;

        public MensajeAI legalizar(TRADE_DOCUMENTOS td)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"exec Legalizacion_Guardar '{td.ID_LEGALIZA}', '{td.NOMBRE_ARCHIVO}'";
            return dbContext.Database.SqlQuery<MensajeAI>(tsql).FirstOrDefault();
        }
        public void eliminarMDLegalizacion(long id)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"delete from TRADE_MDLEGALIZACION where ID_MDLEGALIZACION='{id}'";
            dbContext.Database.ExecuteSqlCommand(tsql);
        }
        public void guardarMDLegalizacion(TRADE_MDLEGALIZACION md)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"update TRADE_MDLEGALIZACION set VALOR='{md.VALOR}' where ID_MDLEGALIZACION = '{md.ID_LEGALIZA}'";
            //string tsql = $"insert into TRADE_MDLEGALIZACION values('{md.ID_LEGALIZA}', '{md.CODPRODUCTO}', '{md.VALOR}')";
            dbContext.Database.ExecuteSqlCommand(tsql);
        }
        public void provicionLegalizacion()
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = "exec PROC_LEGALIZACIONPROVICION";
            dbContext.Database.ExecuteSqlCommand(tsql);
        }
        public void actualizarNprov(long id, int nprov)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"update TRADE_LEGALIZACION set NRO_PROV ='{nprov}' where ID_LEGALIZA='{id}'";
            dbContext.Database.ExecuteSqlCommand(tsql);
        }
        public void actualizarRprov(long id, int rprov)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"update TRADE_LEGALIZACION set NRO_REVPROV ='{rprov}' where ID_LEGALIZA='{id}'";
            dbContext.Database.ExecuteSqlCommand(tsql);
        }
        public void actualizarNSAP(long id, int nsap)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"update TRADE_LEGALIZACION set NRO_SAP ='{nsap}' where ID_LEGALIZA='{id}'";
            dbContext.Database.ExecuteSqlCommand(tsql);
        }
        public List<PLANILLANOTACOMERCIAL> plantillaLegalizacion()
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from trade_viewplantilla_notasdiferenciaprecio where noti=0";
            return dbContext.Database.SqlQuery<PLANILLANOTACOMERCIAL>(tsql).ToList();
        }
        public void updatePlanilla()
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = "update TRADE_LEGALIZACION set  ESTADO=1 where APROBJFTRADE=2 and ESTADO='FALSE' ";
            dbContext.Database.ExecuteSqlCommand(tsql);
        }

        public void updateProvision()
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"exec TRADE_LEGALIZACIONUPDATEPLANPROV";
            dbContext.Database.ExecuteSqlCommand(tsql);
        }

        public List<TRADE_MDLEGALIZACION> detailLegalizacion(long id)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"SELECT * FROM TRADE_VIEWLEGALIZAMD WHERE ID_LEGALIZA='{id}'";
            return dbContext.Database.SqlQuery<TRADE_MDLEGALIZACION>(tsql).ToList();
        }


        public void updatePlanillaProv()
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = "update TRADE_MCNOTACOMERCIAL set NOTI=1 WHERE (ID_CONCEPTO in(16,18,20) and ID_TIPONOTA in(3))";
            dbContext.Database.ExecuteSqlCommand(tsql);
        }

        public void updatePlanillaRProv()
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = "update TRADE_MCNOTACOMERCIAL set ID_TIPONOTA=1 , NOTI=0 where (ID_CONCEPTO in(16,18,20) and ID_TIPONOTA in(4))";
            dbContext.Database.ExecuteSqlCommand(tsql);
        }
    }
}
