using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosRoles
    {
        ModelAplicacionesDescuentos dbcontext = null;

        public int GuardarRoles(ROLES rol)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            dbcontext.ROLES.Add(rol);
            return dbcontext.SaveChanges();
        }

        public List<ROLES> ListadoRoles()
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.ROLES.SqlQuery("Select * from Roles order by namerol").ToList(); ;
        }

    }
}
