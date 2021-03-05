using DataEntitysAplicaciones.DataEntitysDescuentos;
using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;

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
                return JsonConvert.SerializeObject(lgproduct.productos(long.Parse(id.ToString()), mc.CODCLIENTE));
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


        [HttpGet]
        public List<View_Productos> getListProduct(long id)
        {
            lgproduct = new LogicProductos();
            return lgproduct.getListProduct(id);
        }
    }
}
