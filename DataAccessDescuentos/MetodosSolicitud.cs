using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosSolicitud
    {
        ModelAplicacionesDescuentos dbcontext = null;

        public long SaveMCDescuento(MCDESCUENTOS mc)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"exec PROC_SaveMCDESCTO '{mc.ID_SOLICITD}', '{mc.CODCLIENTE}', '{mc.FECINI.ToString("yyyy-MM-dd")}', '{mc.FECFIN.ToString("yyyy-MM-dd")}', '{mc.MOTIVO}','{mc.idmotivos}', '{mc.CEDULA}'";
            long query = dbcontext.Database.SqlQuery<long>(tsql).FirstOrDefault();
            return query;
        }

        public Mensajes SaveMDDescuento(MDDESCUENTO md, short tpsol, long cedula)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"exec PROC_SaveMDDESCTO '{md.ID_MCDESCUENTO}', '{md.CODPRODUCTO}', '{md.PORCENDESC.ToString().Replace(",", ".")}', '{md.CANT}', '{tpsol}', '{md.VUNI.ToString().Replace(",", ".")}', '{cedula}'";
            Mensajes query = dbcontext.Database.SqlQuery<Mensajes>(tsql).FirstOrDefault();
            return query;
        }

        public VIEW_ENCABEZADO Encabezado(long idmc)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from VIEW_ENCABEZADO1 where ID_MCDESCUENTO='{idmc}' order by fecini";
            var result = dbcontext.VIEW_ENCABEZADO.SqlQuery(tsql).FirstOrDefault();
            return result;
        }

        public List<VIEW_ENCABEZADO> ListadoEncabezado(long cedula)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"EXEC Proc_View_Headers '{cedula}'";
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

        public List<VIEW_EXCEL_SAP> ExportarExcel(MCDESCUENTOS fechas)
        {

            dbcontext = new ModelAplicacionesDescuentos();
            var tsql = $"exec Proc_Consolidado '{fechas.FECINI.ToString("yyyy-MM-dd")}', '{fechas.FECFIN.ToString("yyyy-MM-dd")}' ";
            var query = dbcontext.Database.SqlQuery<VIEW_EXCEL_SAP>(tsql).ToList();
            return query;
        }

        public void ActualizarDescarga(long idmd, short tpdcto)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            int i = dbcontext.Database.ExecuteSqlCommand($"exec DescargaExcel '{idmd}', '{tpdcto}'");
        }

        public List<APROBACIONTRADE> listAprobacionTrade()
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = "select * from APROBACIONTRABE";
            return dbcontext.Database.SqlQuery<APROBACIONTRADE>(tsql).ToList();
        }

        public List<VIEW_VENDEDORES> listadoVendedores(MCDESCUENTOS mc)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from VIEW_VENDEDORES where cedula = '{mc.CEDULA}' and convert(date,fecing) between '{mc.FECING.ToString("yyyy-MM-dd")}' and  '{mc.FECFIN.ToString("yyyy-MM-dd")}'";
            return dbcontext.Database.SqlQuery<VIEW_VENDEDORES>(tsql).ToList();
        }

        public List<REPAADMONVENTAS> RepDetalleSolicitudVendedor(MCDESCUENTOS mc)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from REPAADMONVENTAS where cedula = '{mc.CEDULA}' and convert(date,fecing)  between '{mc.FECING.ToString("yyyy-MM-dd")}' and  '{mc.FECFIN.ToString("yyyy-MM-dd")}'";
            return dbcontext.Database.SqlQuery<REPAADMONVENTAS>(tsql).ToList();
        }


        public List<REPAADMONVENTAS> RepDetalleSolicitud(MCDESCUENTOS mc)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from REPAADMONVENTAS where (nivel = '8' or nivel ='9') and convert(date,fecing)  between '{mc.FECING.ToString("yyyy-MM-dd")}' and  '{mc.FECFIN.ToString("yyyy-MM-dd")}'";
            return dbcontext.Database.SqlQuery<REPAADMONVENTAS>(tsql).ToList();
        }

        public List<REPAADMONTRADE> RepDetalleSolicitudTrade()
        {
            dbcontext = new ModelAplicacionesDescuentos();
           string tsql = $"select * from REPAADMONVENTASTRADE where (nivel = '8') and convert(date,fecing) ='{DateTime.Now.ToString("yyyy-MM-dd")}'";
            // string tsql = $"select * from REPAADMONVENTASTRADE where (nivel = '8') and convert(date,fecing) ='2020-03-17'";
            return dbcontext.Database.SqlQuery<REPAADMONTRADE>(tsql).ToList();
        }

        public void UpdateDetalle(long id, string valor)
        {
            ModelAplicacionesDescuentos dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"update MDDESCUENTO set DONWLOADEXCEL= '{valor}' where ID_MDDESCUENTO = '{id}'";
            int i = dbcontext.Database.ExecuteSqlCommand(tsql);
           
        }

        public void EjecutarPrograma()
        {
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.FileName = @"C:\ServicioSAP\ServicioDescuentos.exe";
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.Arguments = "6";
                    process.Start();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

    }
}
