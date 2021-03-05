using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace ServicioDescuentos
{
    public class MetodosPrecios
    {
        private string nodo = "Productoprecio";
        private string url = "/sap/bc/srt/rfc/sap/ysdws_celuweb_descarg_precios/010/ysdws_celuweb_descarg_precios/ysdws_celuweb_descarg_precios_binding";
        private string body =
        "      <urn:YsdrfcFvproductoprecio2>" +
        "         <Pais>CO</Pais>" +
        "        <Productoprecio>" +
        "            <item>" +
        "               <Codproducto></Codproducto>" +
        "               <Codcanal></Codcanal>" +
        "               <Codconpago></Codconpago>" +
        "               <Codorganizacion></Codorganizacion>" +
        "               <Oficina></Oficina>" +
        "               <Zonaventas></Zonaventas>" +
        "               <Grupocli></Grupocli>" +
        "               <Impreferencial></Impreferencial>" +
        "               <Unimed></Unimed>" +
        "            </item>" +
        "         </Productoprecio>" +
        "      </urn:YsdrfcFvproductoprecio2>" ;

        public string Guardar()
        {
            DataServices ds = new DataServices();
            var produclist = ds.ConvertIEnumerable<ProductosPrecios>(ds.SendHeader(body, url, nodo)); 
            var listaprecio = produclist.First().Productoprecio.item.Where(x => x.Grupocli != null).Distinct();
            DbConextServices bulk = new DbConextServices();
            return bulk.guardar("TEMP_PRECIOS", listaprecio);
        }
    }
}
