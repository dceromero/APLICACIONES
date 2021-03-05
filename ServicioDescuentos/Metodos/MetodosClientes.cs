using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace ServicioDescuentos
{
    public class MetodosClientes
    {

        private string nodo = "RESULTADO";
        private string url = "/sap/bc/srt/rfc/sap/ysdws_celuweb_descarg_cliente/010/ysdws_celuweb_descarg_cliente/ysdws_celuweb_descarg_cliente_binding";
         
        private string body(TEMP_CLIENTESECTOR CLIENT)
        {
            var canal = CLIENT.Codcanal == 5 ? "05" : CLIENT.Codcanal.ToString();
            return "<urn:YSDRFC_CELWEB_DESCARG_CLIENTE>" +
"          <CLIENTESECTOR>" +
"            <item>" +
$"               <CODCLIENTE>{CLIENT.Codcliente}</CODCLIENTE>" +
$"               <CODORGANIZACION>{CLIENT.Codorganizacion}</CODORGANIZACION>" +
$"               <CODCANAL>{canal}</CODCANAL>" +
$"               <CODSECTOR>{CLIENT.Codsector}</CODSECTOR>" +
$"               <CODOFICINA>{CLIENT.Codoficina}</CODOFICINA>" +
$"               <CODUSUARIORAZ>{CLIENT.Codusuarioraz}</CODUSUARIORAZ>" +
"               <AUFSD></AUFSD>" +
$"               <ZONAVENTAS>{CLIENT.Zonaventas}</ZONAVENTAS>" +
$"               <GRUPOCLI>{CLIENT.Grupocli}</GRUPOCLI>" +
$"               <ESTADO>{CLIENT.Estado}</ESTADO>" +
"            </item>" +
"         </CLIENTESECTOR>" +
"         <PAIS>CO</PAIS>" +
"         <RESULTADO>" +
"            <item>" +
"               <CODCLIENTE></CODCLIENTE>" +
"               <GRUPOCUENTAS></GRUPOCUENTAS>" +
"               <RAZSOCCLIENTE></RAZSOCCLIENTE>" +
"               <NUMRUC></NUMRUC>" +
"               <DIRCLIENTE></DIRCLIENTE>" +
"               <DISTRITO></DISTRITO>" +
"               <NUMTELEFONO></NUMTELEFONO>" +
"               <CODRESPAGO></CODRESPAGO>" +
"               <IMPLINCREDITO></IMPLINCREDITO>" +
"               <IMPLINCREDITODISPONIBLE></IMPLINCREDITODISPONIBLE>" +
"               <NUMFACPENDIENTES></NUMFACPENDIENTES>" +
"               <IMPTOTVENCIDO></IMPTOTVENCIDO>" +
"               <IMPTOTDEUDA></IMPTOTDEUDA>" +
"               <CODVIAPAGO></CODVIAPAGO>" +
"               <CODCONPAGO></CODCONPAGO>" +
"               <CODCENDISTRIBUCION></CODCENDISTRIBUCION>" +
"              <RUTERO></RUTERO>" +
"               <FLGRUTA></FLGRUTA>" +
"               <GRPCLIENTE></GRPCLIENTE>" +
"               <RAZSOCRESP></RAZSOCRESP>" +
"               <CODBARRAS></CODBARRAS>" +
"               <CODDETALLE></CODDETALLE>" +
"               <SECVISITA></SECVISITA>" +
"            </item>" +
"         </RESULTADO>" +
"      </urn:YSDRFC_CELWEB_DESCARG_CLIENTE>";
        }

        public List<string> Guardar(string codcliente="N")
        {
            ModelAplicacionesDescuentos dbcontext = new ModelAplicacionesDescuentos();
            string tsql = codcliente == "N" ? "select  0 as idclientsect,* from [dbo].[VIEWCLIENTESSECTOR] " : $"select  0 as idclientsect	,* from [dbo].[VIEWCLIENTESSECTOR] where codcliente  = '{codcliente}' ";
            List<string> save = new List<string>();
            foreach (var cliente in dbcontext.Database.SqlQuery<TEMP_CLIENTESECTOR>(tsql).ToList())
            {
                DataServices ds = new DataServices();
                var Clients = ds.ConvertIEnumerable<Clientes>(ds.SendHeaderClientes(body(cliente), url, nodo));
                if (Clients.First().Resultado != null)
                {
                    var clientsList = Clients.First().Resultado.item;
                    clientsList.Codviapago = "0";
                    clientsList.GrupoCuentas = "0";
                    dbcontext.TEMP_CLIENTES.Add(clientsList);
                    int i = dbcontext.SaveChanges();
                    save.Add($"{clientsList.Codcliente} {i.ToString()}");
                    dbcontext.Database.SqlQuery<int>("exec InsertarClienteGeneral");
                }
            }
            return save;
        }
    }
}
