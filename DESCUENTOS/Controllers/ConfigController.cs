using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DESCUENTOS.Controllers
{
    public class ConfigController : Controller
    {
        // GET: Config
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Usuario(long id)
        {
            if (System.Web.HttpContext.Current.Session["id"] != null)
            {
                return View("User",id);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}