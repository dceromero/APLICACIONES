using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosTipoSolicitud
    {
        ModelAplicacionesDescuentos dbcontext = null;

        public List<TIPOSOLICITUD> TpSolicitudes()
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.TIPOSOLICITUD.SqlQuery("select * from TIPOSOLICITUD").ToList();
        }
    }
}
