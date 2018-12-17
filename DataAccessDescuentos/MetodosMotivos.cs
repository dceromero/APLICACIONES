using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosMotivos
    {

        ModelAplicacionesDescuentos dbcontext = null;

        public List<MOTIVOS> MostrarMotivos()
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = "select * from Motivos";
            var result = dbcontext.MOTIVOS.SqlQuery(tsql).ToList();
            return result;
        }

    }
}
