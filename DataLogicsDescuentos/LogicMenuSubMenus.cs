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
            if (Menus != null)
            {
                foreach (var mn in Menus)
                {
                    mtsubmenu = new MetodosSubMenus();
                    mn.SUBMENU = mtsubmenu.ListadoSubMenus(mn.ID_MENU);
                }
            }
            return Menus;
        }
    }
}
