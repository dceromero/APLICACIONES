using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;

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
