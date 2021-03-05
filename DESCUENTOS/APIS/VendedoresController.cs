using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
using System.Web;
using System.Web.Http;

namespace DESCUENTOS.APIS
{
    public class VendedoresController : ApiController
    {
        LogicVendedores lgvend = null;

        [HttpPost]
        public string CodigosVendedores()
        {
            var id = HttpContext.Current.Session["id"];
            if (id != null)
            {
                lgvend = new LogicVendedores();
                var result = lgvend.CodigosVendedores();
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
