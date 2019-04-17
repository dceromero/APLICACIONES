using System.Web.Http;
using DataLogicAplicaciones.DataLogicsDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;
using Newtonsoft.Json;
namespace DESCUENTOS.APIS
{
    public class ProductosController : ApiController
    {


        LogicProductos lgproduct = null;
           
        [HttpPost]
        public string ListadoProductos(MCDESCUENTOS mc)
        {
            var id = System.Web.HttpContext.Current.Session["id"];
            if (id != null)
            {
                lgproduct = new LogicProductos();
                return JsonConvert.SerializeObject(lgproduct.productos(long.Parse(id.ToString()),mc.CODCLIENTE));
            }
            else
            {
                return string.Empty;
            }
        }

        [HttpPost]
        public string ListaProductxCanal(PRECIOS pr)
        {
            var id = System.Web.HttpContext.Current.Session["id"];
            if (id != null)
            {
                lgproduct = new LogicProductos();
                return JsonConvert.SerializeObject(lgproduct.productos(pr));
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
