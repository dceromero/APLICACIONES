using DataEntitysAplicaciones.DataEntitysDescuentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosVendedores
    {

        ModelAplicacionesDescuentos dbcontext = null;

        public List<VENDEDORES> CodigosVendedores()
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = "select * from VENDEDORES where COD_VENDEDOR not in (select COD_VENDEDOR from USUARIOS where ESTADO = 1)";
            var result = dbcontext.VENDEDORES.SqlQuery(tsql).ToList();
            return result;
        }

    }
}
