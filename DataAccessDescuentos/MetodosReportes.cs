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
    }
}
