using DataAccessAplicaciones.DataAccessDescuentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioDescuentos
{
    public class MetodosClienteSector
    {
        private string nodo = "Clientesector";
        private string url = "/sap/bc/srt/rfc/sap/ysdws_celuweb_descar_cliensect/010/ysdws_celuweb_descar_cliensect/ysdws_celuweb_descar_cliensect_binding";
        private string body =
        "<urn:YsdrfcFvclientesector>" +
"        <Clientesector>" +
"            <item>" +
"               <Codcliente></Codcliente>" +
"               <Codorganizacion></Codorganizacion>" +
"               <Codcanal></Codcanal>" +
"               <Codsector></Codsector>" +
"               <Codoficina></Codoficina>" +
"               <Codusuarioraz></Codusuarioraz>" +
"               <Aufsd></Aufsd>" +
"               <Zonaventas></Zonaventas>" +
"               <Grupocli></Grupocli>" +
"               <Estado></Estado>" +
"            </item>" +
"         </Clientesector>" +
"         <Pais>CO</Pais>" +
"</urn:YsdrfcFvclientesector>";

        public string Guardar()
        {
            string save = "";
            try
            {
                DataServices ds = new DataServices();
                ModelAplicacionesDescuentos dbcontext = new ModelAplicacionesDescuentos();
                dbcontext.Database.ExecuteSqlCommand("exec EliminarClienteSectorTemp");
                dbcontext.SaveChanges();
                var producclientsec = ds.ConvertIEnumerable<ClientesSector>(ds.SendHeader(body, url, nodo));
                var listaclientsec = producclientsec.First().Clientesector.item.Distinct();
                DbConextServices bulk = new DbConextServices();
                save = bulk.guardar("TEMP_CLIENTESECTOR", listaclientsec);
                dbcontext.Database.ExecuteSqlCommand("exec InsertarClienteSector");
                dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                save = ex.Message.ToString();
            }

            return save;
        }
    }
}
