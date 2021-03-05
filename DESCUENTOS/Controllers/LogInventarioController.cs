using System.Web.Mvc;

namespace DESCUENTOS.Controllers
{
    public class LogInventarioController : Controller
    {
        // GET: LogInventario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetalleInventario(long id)
        {
            return View("DetailInventario", id);
        }

        public ActionResult DetalleSupervisor(long id)
        {
            return View("DetailSup", id);
        }

        public ActionResult ListInventario()
        {
            return View();
        }


        public ActionResult ListSupervisor()
        {
            return View("ListStateSup");
        }

        public ActionResult ListAprobMasiva()
        {
            return View("AprobGerencias");
        }

        public ActionResult ListContabilidad()
        {
            return View("ListStateContab");
        }


        public ActionResult InformeInventario()
        {
            return View("InfoInventary");
        }

        public ActionResult InformeAcumulado()
        {
            return View("InfoAcumulado");
        }

        public ActionResult InformeEstados()
        {
            return View("InfoState");
        }
    }
}