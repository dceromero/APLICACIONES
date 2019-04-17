using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;

namespace DESCUENTOS.APIS
{
    public class OficinasController : ApiController
    {
        LogicOficinas logOfi = null;
        [HttpPost]
        public string ListadoOfixReg(string id)
        {
            logOfi = new LogicOficinas();
            return JsonConvert.SerializeObject(logOfi.ListadoOfixReg(id));
        }
    }
}
