using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosSolicitud
    {
        ModelAplicacionesDescuentos dbcontext = null;

        public long SaveMCDescuento(MCDESCUENTOS mc)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"exec PROC_SaveMCDESCTO '{mc.ID_SOLICITD}', '{mc.CODCLIENTE}', '{mc.FECINI.ToString("yyyy-MM-dd")}', '{mc.FECFIN.ToString("yyyy-MM-dd")}', '{mc.MOTIVO}','{mc.idmotivos}'";
            long query = dbcontext.Database.SqlQuery<long>(tsql).FirstOrDefault();
            return query;
        }

        public Mensajes SaveMDDescuento(MDDESCUENTO md, short tpsol)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"exec PROC_SaveMDDESCTO '{md.ID_MCDESCUENTO}', '{md.CODPRODUCTO}', '{md.PORCENDESC}', '{md.CANT}', '{tpsol}'";
            Mensajes query = dbcontext.Database.SqlQuery<Mensajes>(tsql).FirstOrDefault();
            return query;
        }

        public VIEW_ENCABEZADO Encabezado(long idmc)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from VIEW_ENCABEZADO where ID_MCDESCUENTO='{idmc}' order by fecini";
            var result = dbcontext.VIEW_ENCABEZADO.SqlQuery(tsql).FirstOrDefault();
            return result;
        }

        public List<VIEW_ENCABEZADO> ListadoEncabezado(long cedula)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from VIEW_ENCABEZADO where estado <>0 and nivel = (select NIVELUSUARIO-1 from USUARIOS where CEDULA = '{cedula}') order by fecini";
            var result = dbcontext.VIEW_ENCABEZADO.SqlQuery(tsql).ToList();
            return result;
        }

        public List<VIEW_VALORPORCLIENTE> ProductosClientes(long idmc)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"select ID_MDDESCUENTO, Material, PORCENDESC, CANT, subtotal, Descuento, total, estado from VIEW_VALORPORCLIENTE where ID_MCDESCUENTO = '{idmc}'";
            var result = dbcontext.Database.SqlQuery<VIEW_VALORPORCLIENTE>(tsql).ToList();
            return result;
        }

        public Mensajes UpdateMDDescuentos(MDDESCUENTO md, long cc)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            String tsql = $"exec PROC_APROBACION_COMERCIAL '{cc}','{md.ID_MDDESCUENTO}','{md.VERIFICA1}', '{md.OBS}'";
            var query = dbcontext.Database.SqlQuery<Mensajes>(tsql).FirstOrDefault();
            return query;
        }

        public List<VIEW_ENCABEZADO_INFORME> EncabezadoInformes()
        {
            dbcontext = new ModelAplicacionesDescuentos();
            var query = dbcontext.Database.SqlQuery<VIEW_ENCABEZADO_INFORME>("select * from VIEW_ENCABEZADO_INFORME").ToList();
            return query;
        }

        public List<VIEW_EXCEL_SAP> ExportarExcel(long idmc)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            var query = dbcontext.Database.SqlQuery<VIEW_EXCEL_SAP>($"select * from VIEW_EXCEL_SAP where ID_MCDESCUENTO='{idmc}' ").ToList();
            return query;
        }










































































































































































































































































































































    }
}
