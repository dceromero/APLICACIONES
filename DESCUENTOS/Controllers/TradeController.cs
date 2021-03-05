using System.Web.Mvc;

namespace DESCUENTOS.Controllers
{
    public class TradeController : Controller
    {
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

        public ActionResult ListAprobacion()
        {
            if (System.Web.HttpContext.Current.Session["id"] != null)
            {
                return View("ReveNew");
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
                return View("AprobacionNotasComerciales", id);
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

        public ActionResult ListSupvisor()
        {
            if (System.Web.HttpContext.Current.Session["id"] != null)
            {
                return View("listmodificacion");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        
        public ActionResult Modificacion(long id)
        {
            if (System.Web.HttpContext.Current.Session["id"] != null)
            {
                return View("AprobacionSupervisor", id);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Estados()
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
        public ActionResult ListAdmonsale()
        {
            if (System.Web.HttpContext.Current.Session["id"] != null)
            {
                return View("listAdmonSale");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        public ActionResult Informe()
        {
            if (System.Web.HttpContext.Current.Session["id"] != null)
            {
                return View("Informerevenew");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
