using System.Web.Http;
using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
namespace DESCUENTOS.APIS
{
    public class ProductosController : ApiController
    {
        LogicProductos lgproduct = null;

        [HttpPost]
        public string ListadoProductos()
        {
            lgproduct = new LogicProductos();
            return JsonConvert.SerializeObject(lgproduct.productos());
        }
    }
}
