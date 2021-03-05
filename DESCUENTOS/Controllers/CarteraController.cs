using System.Web.Mvc;

namespace DESCUENTOS.Controllers
{
    public class CarteraController : Controller
    {
        // GET: Cartera
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Aprobaciones()
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

        public ActionResult SubirArchivo()
        {
            return View("FileUpInfo");
        }

        public ActionResult Aprobacion(long id)
        {
            if (System.Web.HttpContext.Current.Session["id"] != null)
            {
                return View("AprobacionCartera", id);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult InformeGeneral()
        {
            if (System.Web.HttpContext.Current.Session["id"] != null)
            {
                return View("InformeCartera");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}