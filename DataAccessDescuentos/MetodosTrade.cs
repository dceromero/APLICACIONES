using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;
using Org.BouncyCastle.Math;

namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosTrade
    {
        private ModelAplicacionesDescuentos dbContext = null;

        public List<TIPOSOLICITUD> listTipoSolicitud(short id)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from dbo.trade_funcTipoSolicitud('{id}')";
            return dbContext.Database.SqlQuery<TIPOSOLICITUD>(tsql).ToList();
        }

        public List<TIPODENOTA> listNotas()
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = "select * from TIPODENOTA ";
            return dbContext.Database.SqlQuery<TIPODENOTA>(tsql).ToList();
        }

        public List<TRADE_VIEWCONCEPTO> listConceptos(long codcliente)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from TRADE_VIEWCONCEPTO WHERE ID_CANAL='1' OR ID_CANAL IN (" +
                $"SELECT  ID_CANAL from CLIENTES_SECTOR WHERE CODCLIENTE = '{codcliente}')";
            return dbContext.Database.SqlQuery<TRADE_VIEWCONCEPTO>(tsql).ToList();
        }

        public MensajeAI saveMCNotaXPrecio(TRADE_MCNOTAXPRECIO nota)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"exec Trade_GuardarNotaXPrecio '{nota.CEDULA}', '{nota.COD_CLIEN}', '{nota.NIT}', '{nota.ID_TIPONOTA}'," +
                $"'{nota.ID_SOLICITD}', '{nota.NUM_FACTURA}','{nota.ID_CONCEPTO}','{nota.JUSTIFICACION}'," +
                $"'{nota.FECHA_INIAC.ToString("yyyy-MM-dd")}', '{nota.FECHA_FINAC.ToString("yyyy-MM-dd")}', '{nota.VENTA_PROMEDIO}', '{nota.VENTA_ESPERADA}' ";
            return dbContext.Database.SqlQuery<MensajeAI>(tsql).FirstOrDefault();
        }

        public void saveMDNotaxPrecio(TRADE_MDNOTAXPRECIO md)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"insert into TRADE_MDNOTACOMERCIAL values('{md.ID_MCNOTAXPRECIO}', '{md.CODPRODUCTO}', '{md.VALOR}')";
            dbContext.Database.ExecuteSqlCommand(tsql);
        }

        public List<TRADE_VIEWNOTA> listNotasEstados(long cedula)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from TRADE_VIEWNOTA where CEDULA='{cedula}' and CONCEPTO like '%DIFERENCIA%' order by ID_MCNOTACOMERCIAL desc";
            return dbContext.Database.SqlQuery<TRADE_VIEWNOTA>(tsql).ToList();
        }

        public List<TRADE_VIEWNOTA> listNotasEstadosActivacion(long cedula)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from TRADE_VIEWNOTA where CEDULA='{cedula}'  " +
                $"and ID_MCNOTACOMERCIAL  not in(select ID_MCNOTACOMERCIAL from TRADE_LEGALIZACION where ENVIOSUP =1) " +
                $"and CONCEPTO like '%ACTIVACION%' order by ID_MCNOTACOMERCIAL desc";
            return dbContext.Database.SqlQuery<TRADE_VIEWNOTA>(tsql).ToList();
        }


        public List<TRADE_VIEWDIFPRECIOS> listNotasLegalizada(long cedula)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from TRADE_VIEWDIFPRECIOS where CEDULA='{cedula}' order by FEC_INGRESO desc ";
            return dbContext.Database.SqlQuery<TRADE_VIEWDIFPRECIOS>(tsql).ToList();
        }

        public TRADE_LEGALIZACION notaLegalizacion(long id)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from TRADE_LEGALIZACION where ID_MCNOTACOMERCIAL ='{id}'";
            return dbContext.Database.SqlQuery<TRADE_LEGALIZACION>(tsql).FirstOrDefault();
        }

        public List<TRADE_MDLEGALIZACION> detailLegalizacion(long id)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from TRADE_VIEWPRODUCTOLEGAL where ID_LEGALIZA ='{id}'";
            return dbContext.Database.SqlQuery<TRADE_MDLEGALIZACION>(tsql).ToList();
        }
        public List<TRADE_VIEWNOTA> listNotasComerciales(long cedula)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"EXEC TRADE_VIEWAPROBACIONNOTASCOMERCIALES '{cedula}'";
            return dbContext.Database.SqlQuery<TRADE_VIEWNOTA>(tsql).ToList();
        }

        public TRADE_VIEWNOTA NotasAprobacion(long idmc)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from TRADE_VIEWNOTA where  ID_MCNOTACOMERCIAL='{idmc}'  ";
            return dbContext.Database.SqlQuery<TRADE_VIEWNOTA>(tsql).FirstOrDefault();
        }

        public void updatePlanilla()
        {

            dbContext = new ModelAplicacionesDescuentos();
            string tsql = "update TRADE_MCNOTACOMERCIAL set FEC_DESCARGA= getdate(), noti=1 where APROBGERREG=2 and NOTI='FALSE' ";
            dbContext.Database.ExecuteSqlCommand(tsql);
        }

        public List<PLANILLANOTACOMERCIAL> planilla()
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from trade_funcviewplanilla(0)  ";
            return dbContext.Database.SqlQuery<PLANILLANOTACOMERCIAL>(tsql).ToList();
        }

        public List<PLANILLANOTACOMERCIAL> planillaProv()
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from trade_viewplantilla_provcomerciales ";
            return dbContext.Database.SqlQuery<PLANILLANOTACOMERCIAL>(tsql).ToList();
        }

        public List<PLANILLANOTACOMERCIAL> planillaRProv()
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from trade_viewplantilla_rprovcomerciales ";
            return dbContext.Database.SqlQuery<PLANILLANOTACOMERCIAL>(tsql).ToList();
        }


        public List<TRADE_MDNOTAXPRECIO> listDetailAprobacion(long idmc)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from TRADE_VIEWPRODUCTOS where  ID_MCNOTACOMERCIAL='{idmc}' ";
            return dbContext.Database.SqlQuery<TRADE_MDNOTAXPRECIO>(tsql).ToList();
        }

        public MensajeAI aprobarNotasComerciales(TRADE_MCNOTAXPRECIO nota)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"exec TRADE_NOTASCOMERCIALES '{nota.APROBCOORTD}', '{nota.CEDULA}', '{nota.ID_MCNOTAXPRECIO}', '{nota.OBS_COORTRADE}' ";
            return dbContext.Database.SqlQuery<MensajeAI>(tsql).FirstOrDefault();
        }

        public void Eliminar(long id)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"delete from TRADE_MDNOTACOMERCIAL where ID_MDNOTACOMERCIAL='{id}'";
            dbContext.Database.ExecuteSqlCommand(tsql);
        }

        public List<TRADE_VIEWNOTA> listAdmonSales()
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = "Select * from TRADE_VIEWNOTA where CONCEPTO NOT LIKE '%6.1 - ACTIVACION COMERCIAL%' AND APROBGERREG='2' and ESTADO='0'";
            return dbContext.Database.SqlQuery<TRADE_VIEWNOTA>(tsql).ToList();
        }

        public List<TRADE_VIEWDIFPRECIOS> listAdmonComercial()
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = "Select * from TRADE_VIEWDIFPRECIOS order by FEC_INGRESO desc";
            return dbContext.Database.SqlQuery<TRADE_VIEWDIFPRECIOS>(tsql).ToList();
        }

        public List<TRADE_VIEWDIFPRECIOS> listAdmonComercial(TRADE_MCNOTAXPRECIO fechas)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"Select * from TRADE_VIEWDIFPRECIOS where FEC_INGRESO between '{fechas.FEC_INGRESO.ToString("yyyy-MM-dd")}' and {fechas.FEC_DESCARGA.ToString("yyyy-MM-dd")}'";
            return dbContext.Database.SqlQuery<TRADE_VIEWDIFPRECIOS>(tsql).ToList();
        }

        public MensajeAI updateAdmonSales(TRADE_MCNOTAXPRECIO nota)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"exec TRADE_UPDATEADMONSALES '{nota.CEDULA}', '{nota.ID_MCNOTAXPRECIO}', '{nota.OBS_COORTRADE}', '{nota.APROBCOORTD}'";
            return dbContext.Database.SqlQuery<MensajeAI>(tsql).FirstOrDefault();
        }

        public List<TRADE_INFORMEREVENEW> informeNotas(TRADE_MCNOTAXPRECIO nota)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from TRADE_INFORMEREVENEW where convert(date,fec_ingreso) between '{nota.FEC_INGRESO.ToString("yyyy-MM-dd")}' and '{nota.FEC_DESCARGA.ToString("yyyy-MM-dd")}'";
            return dbContext.Database.SqlQuery<TRADE_INFORMEREVENEW>(tsql).ToList();
        }


        public List<TRADE_DOCUMENTOS> legalizacionDocumentos(long id)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from TRADE_DOCUMENTOS where ID_LEGALIZA ='{id}' ";
            return dbContext.Database.SqlQuery<TRADE_DOCUMENTOS>(tsql).ToList();
        }

        public List<TRADE_VIEWDIFPRECIOS> ListAprobLegalizacion(long cedula)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"exec TRADE_VIEWAPROBDIFERENCIAPRECIO {cedula}";
            return dbContext.Database.SqlQuery<TRADE_VIEWDIFPRECIOS>(tsql).ToList();
        }

        public List<TRADE_DOCUMENTOS> listDocumentosLegal(long id)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"Select * from TRADE_DOCUMENTOS where ID_LEGALIZA='{id}'";
            return dbContext.Database.SqlQuery<TRADE_DOCUMENTOS>(tsql).ToList();
        }
        public TRADE_VIEWDIFPRECIOS tradeLegalizacion(long id)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from TRADE_VIEWDIFPRECIOS where ID_LEGALIZA='{id}'";
            return dbContext.Database.SqlQuery<TRADE_VIEWDIFPRECIOS>(tsql).FirstOrDefault();
        }

        public List<TRADE_MDLEGALIZACION> listTradeLegalizacion(long id)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from TRADE_MDLEGALIZACION where ID_LEGALIZA='{id}'";
            return dbContext.Database.SqlQuery<TRADE_MDLEGALIZACION>(tsql).ToList();
        }

        public MensajeAI AprobLegalizacion(TRADE_MCNOTAXPRECIO nota)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"exec Trade_AprobacionDiferenciaPrecio '{nota.APROBCOORTD}', '{nota.CEDULA}', '{nota.ID_MCNOTAXPRECIO}', '{nota.OBS_COORTRADE}' ";
            return dbContext.Database.SqlQuery<MensajeAI>(tsql).FirstOrDefault();
        }

        public List<TRADE_VIEWINFORMESOLICITUD> informSolicitud(long cedula,TRADE_VIEWINFORMESOLICITUD vm)
        {
            dbContext = new ModelAplicacionesDescuentos();
            string tsql = $"exec PROC_VIEWCOORDINADORTRADE '{cedula}', '{vm.FECHA_INIAC.ToString("yyyy-MM-dd")}', '{vm.FECHA_FINAC.ToString("yyyy-MM-dd")}'";
            //string tsql = $"Select * from TRADE_VIEWINFORMESOLICITUD where FEC_INGRESO between '{vm.FECHA_INIAC.ToString("yyyy-MM-dd")}' and '{vm.FECHA_FINAC.ToString("yyyy-MM-dd")}' ";
            return dbContext.Database.SqlQuery<TRADE_VIEWINFORMESOLICITUD>(tsql).ToList();
        }

    }
}
