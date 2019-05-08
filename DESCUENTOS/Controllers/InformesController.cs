using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace DESCUENTOS.Controllers
{
    public class InformesController : Controller
    {
        // GET: Informes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetalleSolicitud()
        {
            return View();
        }

        public ActionResult Solicitudes()
        {
            if (System.Web.HttpContext.Current.Session["id"] != null)
            {
                return View("InformeVendedor");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Consolidado()
        {
            return View();
        }

        public ActionResult ReportePI()
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