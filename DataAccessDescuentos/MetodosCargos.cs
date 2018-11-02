using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosCargos
    {
        ModelAplicacionesDescuentos dbcontext = null;

        public List<CARGOS> ListadoCargos()
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.CARGOS.SqlQuery("select * from CARGOS order by NAMECARGO").ToList();
        }
    }
}
