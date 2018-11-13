using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicSolicitudes
    {
        
        public List<TIPOSOLICITUD> ListarTiposSolicitudes()
        {
            MetodosTipoSolicitud mttpSolictudes = new MetodosTipoSolicitud();
            return mttpSolictudes.TpSolicitudes();
        }
    }
}
