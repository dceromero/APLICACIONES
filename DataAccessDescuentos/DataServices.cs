using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class DataServices
    {
        private string user = "CO_SLMVVENTA";
        private string psw = "california";

        public DataServices(string _user, string _psw)
        {
            user = _user;
            psw = _psw;
        }

        public DataServices()
        {
        }

        public string SendHeaderClientes(string body, string url, string nodo)
        {
            string head = "<soap:Envelope xmlns:soap='http://www.w3.org/2003/05/soap-envelope' xmlns:urn='urn:sap-com:document:sap:rfc:functions'>  " +
                    "   <soap:Body>" +
           body +
           "   </soap:Body>" +
           "</soap:Envelope>"
           ;
            string js = "";
            using (WebClient myWebClient = new WebClient())
            {
                //myWebClient.BaseAddress = "http://glsapap1.gloria.com.pe:1080";
                myWebClient.BaseAddress = "http://10.2.30.225:1080";
                myWebClient.UseDefaultCredentials = true;
                myWebClient.Credentials = new NetworkCredential(user, psw);

                myWebClient.Headers.Add("content-type", "application/soap+xml; charset=utf-8");
                var MyData = myWebClient.UploadString(url, head);

                XmlDocument xmltest = new XmlDocument();
                xmltest.LoadXml(MyData);
                XmlNodeList elemlist = xmltest.GetElementsByTagName(nodo);
                try
                {
                    js = JsonConvert.SerializeObject(elemlist);
                }
                catch (Exception ex)
                {
                    var error = ex.Message.ToString();
                }

                var st = js.Split(',');
            }
            return js;
        }


        public string SendHeader(string body, string url, string nodo)
        {
            // string head = "<soap:Envelope xmlns:soap='http://www.w3.org/2003/05/soap-envelope' xmlns:urn='urn:sap-com:document:sap:rfc:functions'>  " +
            string head = "<soap:Envelope xmlns:soap='http://www.w3.org/2003/05/soap-envelope' xmlns:urn='urn:sap-com:document:sap:soap:functions:mc-style'>  " +
                  "   <soap:Body>" +
          body +
          "   </soap:Body>" +
          "</soap:Envelope>"
          ;
            string js = "";
            using (WebClient myWebClient = new WebClient())
            {
                // myWebClient.BaseAddress = "http://glsapap1.gloria.com.pe:1080";
                myWebClient.BaseAddress = "http://10.2.30.225:1080";
                myWebClient.UseDefaultCredentials = true;
                myWebClient.Credentials = new NetworkCredential(user, psw);

                myWebClient.Headers.Add("content-type", "application/soap+xml; charset=utf-8");
                var MyData = myWebClient.UploadString(url, head);

                XmlDocument xmltest = new XmlDocument();
                xmltest.LoadXml(MyData);
                XmlNodeList elemlist = xmltest.GetElementsByTagName(nodo);
                js = JsonConvert.SerializeObject(elemlist);
                var st = js.Split(',');
            }
            return js;
        }


        public string SendDescuento(string body, string url, string nodo)
        {
            // string head = "<soap:Envelope xmlns:soap='http://www.w3.org/2003/05/soap-envelope' xmlns:urn='urn:sap-com:document:sap:rfc:functions'>  " +
            string head = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:urn='urn:sap-com:document:sap:rfc:functions'> " +
                   "<soapenv:Header/>" +
                  "   <soapenv:Body>" +
          body +
          "   </soapenv:Body>" +
          "</soapenv:Envelope>"
          ;
            string js = "";
            using (WebClient myWebClient = new WebClient())
            {
                // myWebClient.BaseAddress = "http://glsapap1.gloria.com.pe:1080";

                myWebClient.BaseAddress = "http://10.2.30.225:1080";
                myWebClient.UseDefaultCredentials = true;
                myWebClient.Credentials = new NetworkCredential(user, psw);

                myWebClient.Headers.Add("content-type", "text/xml; charset=utf-8");
                try
                {
                    var MyData = myWebClient.UploadString(url, head);
                    XmlDocument xmltest = new XmlDocument();
                    xmltest.LoadXml(MyData);
                    XmlNodeList elemlist = xmltest.GetElementsByTagName(nodo);
                     JsonConvert.SerializeObject(elemlist);
                    js = "1";
                }
                catch (Exception ex)
                {
                    ModelAplicacionesDescuentos dbcontext = new ModelAplicacionesDescuentos();
                    ERRORES error = new ERRORES();
                    error.FECHA = DateTime.Now;
                    error.LINEADELERROR = 0;
                    error.PRODUJOERROR = ex.Message;
                    error.MENSAJE = ex.Message;
                    dbcontext.ERRORES.Add(error);
                    dbcontext.SaveChanges();
                    js = "10";
                }

            }
            return js;
        }

        public IEnumerable<T> ConvertIEnumerable<T>(string data)
        {
            IEnumerable<T> result = null;
            try
            {
                result = JsonConvert.DeserializeObject<IEnumerable<T>>(data);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return result;
        }
    }
}
