using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosRegionales
    {

        ModelAplicacionesDescuentos dbcontext = null;
        public List<REGIONALES> ListadoRegionales()
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.REGIONALES.SqlQuery("select * from regionales ORDER BY NAMEREGIONAL").ToList();
        }

    }
}
