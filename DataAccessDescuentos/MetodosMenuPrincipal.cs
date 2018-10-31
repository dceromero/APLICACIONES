using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosMenuPrincipal
    {
        ModelAplicacionesDescuentos dbcontext = null;

        public List<MENU> ListadoMenuPrincipal(long cedula)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.MENU.SqlQuery($"select * from Func_MenuPrincipal('{cedula}')").ToList();
        }
    }
}
