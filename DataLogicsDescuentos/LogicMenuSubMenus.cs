using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicMenuSubMenus
    {
        MetodosMenuPrincipal mtmenu = null;
        MetodosSubMenus mtsubmenu = null;

        public List<MENU> ListadoMenusSubmenus(long cedula)
        {
            mtmenu = new MetodosMenuPrincipal();
            List<MENU> Menus = mtmenu.ListadoMenuPrincipal(cedula);
            foreach(var m in Menus)
            {
                mtsubmenu = new MetodosSubMenus();
                m.SUBMENU = mtsubmenu.ListadoSubMenus(m.ID_MENU,cedula);
            }
            return Menus;
        }

        public List<SUBMENU> ListadoSubMenus()
        {
            mtsubmenu = new MetodosSubMenus();
            return mtsubmenu.ListadoSubMenus();
        }
        
    }
}
