using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosReportes
    {
        ModelAplicacionesDescuentos dbcontext = null;

        public List<VIEW_REP_DETALLE_SOLICITUD> DetalleSolicitud(DateTime fecini, DateTime fecfin)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from VIEW_REP_DETALLE_SOLICITUD where FECING between '{fecini.ToString("yyyy-MM-dd")}' and '{fecfin.ToString("yyyy-MM-dd")}'";
            var result = dbcontext.Database.SqlQuery<VIEW_REP_DETALLE_SOLICITUD>(tsql).ToList();
            return result;
        }

        public List<VIEW_ENCABEZADO_INFORME> InformexVendedor(MCDESCUENTOS info)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from Func_ReporteXVendedor('{info.CEDULA}','{info.FECINI.ToString("yyyy-MM-dd")}','{info.FECFIN.ToString("yyyy-MM-dd")}')";
            var result = dbcontext.Database.SqlQuery<VIEW_ENCABEZADO_INFORME>(tsql).ToList();
            return result;
        }
    }
}
