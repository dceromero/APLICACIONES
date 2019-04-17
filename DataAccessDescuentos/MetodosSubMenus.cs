using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosSubMenus
    {
        ModelAplicacionesDescuentos dbcontext = null;

        public List<SUBMENU> ListadoSubMenus()
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.SUBMENU.SqlQuery($"select * from submenu  order by NAMESUBMENU").ToList();
        }

        public List<SUBMENU> ListadoSubMenus(short ID_MENU, long cedula)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.SUBMENU.SqlQuery($"select * from Func_SubMenus('{cedula}', '{ID_MENU}')order by NAMESUBMENU").ToList();
        }

    }
}
