using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicReportes
    {

        MetodosReportes mtreport = null;

        public List<VIEW_REP_DETALLE_SOLICITUD> DetalleSolicitud(DateTime fecini, DateTime fecfin)
        {
            mtreport = new MetodosReportes();
            return mtreport.DetalleSolicitud(fecini, fecfin);
        }

        public List<VIEW_ENCABEZADO_INFORME> InformeVendedor(MCDESCUENTOS info)
        {
            mtreport = new MetodosReportes();
            return mtreport.InformexVendedor(info);
        }
    }
}
