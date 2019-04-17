using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View("InformeVendedor");
        }

        public ActionResult Consolidado()
        {
            return View();
        }
    }
}