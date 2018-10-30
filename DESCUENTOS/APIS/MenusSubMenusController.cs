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
            if (HttpContext.Current.Session["id"] != null)
            {
                logmenusubmenu = new LogicMenuSubMenus();
                List<MENU> menus = logmenusubmenu.ListadoMenusSubmenus(long.Parse(HttpContext.Current.Session["id"].ToString()));
                return JsonConvert.SerializeObject(menus);
            }
            else
            {
                return null;
            }
        }
    }
}
