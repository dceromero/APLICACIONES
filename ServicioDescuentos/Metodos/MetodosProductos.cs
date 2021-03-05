using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAplicaciones.DataAccessDescuentos;

namespace ServicioDescuentos
{
    public class MetodosProductos
    {
        private string nodo = "Resultado";
        private string url = "/sap/bc/srt/rfc/sap/ysdws_celuweb_descarg_producto/010/ysdws_celuweb_descarg_producto/ysdws_celuweb_descarg_producto_binding";
                

        private string body(string cod)
        {
            return "  <urn:YsdrfcCelwebDescargProducto>" +
"         <Lineaproducto>" +
"            <item>" +
$"               <Codlinproducto>{cod}</Codlinproducto>" +
"               <Codtipproducto></Codtipproducto>" +
"               <Descripcion></Descripcion>" +
"               <Desctipproducto></Desctipproducto>" +
"               <Estado></Estado>" +
"            </item>" +
"         </Lineaproducto>" +
"         <Pais>CO</Pais>" +
"         <Resultado>" +
"            <item>" +
"               <Codproducto></Codproducto>" +
"               <Descripcion></Descripcion>" +
"               <Uniminima></Uniminima>" +
"               <Pesuniminima></Pesuniminima>" +
"               <Voluniminima></Voluniminima>" +
"               <Figbonificacion></Figbonificacion>" +
"               <Estado></Estado>" +
"              <Grmateriales></Grmateriales>" +
"               <Umedestadistica></Umedestadistica>" +
"               <Flgsujetobonif></Flgsujetobonif>" +
"               <Clasificacionfiscal></Clasificacionfiscal>" +
"            </item>" +
"         </Resultado>" +
"      </urn:YsdrfcCelwebDescargProducto>";
        }
        
        public List<string> Guardar()
        {
            ModelAplicacionesDescuentos dbcontext = new ModelAplicacionesDescuentos();
            List<string> save =new  List<string>();
            foreach (var linea in dbcontext.LINEAS.ToList())
            {
                DataServices ds = new DataServices();
                var produclist = ds.ConvertIEnumerable<Productos>(ds.SendHeader(body(linea.cod), url, nodo));
                var listaProductos = produclist.First().Resultado.item.Distinct();
                DbConextServices bulk = new DbConextServices();
                save.Add($"{linea.cod} {bulk.guardar("TEMP_PRODUCTOS", listaProductos)}");
            }
            return save;
        }
    }
}
