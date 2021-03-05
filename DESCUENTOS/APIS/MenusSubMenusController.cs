using DataEntitysAplicaciones.DataEntitysDescuentos;
using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
namespace DESCUENTOS.APIS
{
    public class MenusSubMenusController : ApiController
    {
        LogicMenuSubMenus logmenusubmenu = null;

        [HttpPost]
        public string Menus()
        {
            var id = HttpContext.Current.Session["id"];
            if (id != null)
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
