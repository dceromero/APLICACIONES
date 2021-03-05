using System.Web.Mvc;

namespace DESCUENTOS.Controllers
{
    public class InformesController : Controller
    {
        // GET: Informes
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

        public ActionResult DetalleSolicitud()
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

        public ActionResult Canal()
        {
            if (System.Web.HttpContext.Current.Session["id"] != null)
            {
                return View("InformeCanal");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Consolidado()
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

        public ActionResult DescVendedor()
        {
            if (System.Web.HttpContext.Current.Session["id"] != null)
            {
                return View("DescuentoVendedor");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        public ActionResult NotasComerciales()
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

        public ActionResult NewConsolidado()
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

        public ActionResult InformeTradeSolicitudes()
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