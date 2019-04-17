using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosOficVentas
    {


        ModelAplicacionesDescuentos dbcontext = null;
        public List<OFICVENTAS> ListadoOfixReg(string idr)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.OFICVENTAS.SqlQuery($"select * from OFICVENTAS where ID_REGIONAL ='{idr}' ORDER BY NAMEOFICVENTA").ToList();
        }
    }
}
