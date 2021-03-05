using System.Web.Mvc;

namespace DESCUENTOS.Controllers
{
    public class DescuentosController : Controller
    {
        // GET: Descuentos
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

        public ActionResult Canal()
        {
            return View();
        }

        public ActionResult Autorizaciones()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AutorizacionesCanal()
        {
            return View("AutorizacionClient");
        }

        [HttpGet]
        public ActionResult AutorizacionCanal(long id)
        {
            return View("AutorizacionCanal", id);
        }

        public ActionResult Autorizacion(long id)
        {
            return View(id);
        }

        public ActionResult DetalleDescuento(long id)
        {
            return View(id);
        }

        public ActionResult Trade()
        {
            return View();
        }
    }
}