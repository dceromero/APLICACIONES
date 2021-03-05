using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DESCUENTOS.Controllers
{
    public class LegalizacionController : Controller
    {
        // GET: Legalizacion
        public ActionResult Index(long id)
        {
            if (System.Web.HttpContext.Current.Session["id"] != null)
            {
                return View("Index", id);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        public ActionResult ListAprobacion()
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

        public ActionResult Aprobacion(long id)
        {
            if (System.Web.HttpContext.Current.Session["id"] != null)
            {
                return View(id);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult ListAdmonSales()
        {
            if (System.Web.HttpContext.Current.Session["id"] != null)
            {
                return View("listadmonsale");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Planilla()
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


    }
}