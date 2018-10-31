using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using DataLogicAplicaciones.DataLogicsDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DESCUENTOS.APIS
{
    public class MenusSubMenusController : ApiController
    {
        LogicMenuSubMenus logmenusubmenu = null;

        [HttpPost]
        public string Menus()
        {
            var id = System.Web.HttpContext.Current.Session["id"];
            if (id!= null)
            {
                logmenusubmenu = new LogicMenuSubMenus();
                List<MENU> menus = logmenusubmenu.ListadoMenusSubmenus(long.Parse(id.ToString()));
                return JsonConvert.SerializeObject(menus);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public string Submenus()
        {
            var id = System.Web.HttpContext.Current.Session["id"];
            if (id != null)
            {
                logmenusubmenu = new LogicMenuSubMenus();
                return JsonConvert.SerializeObject(logmenusubmenu.ListadoSubMenus());
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
