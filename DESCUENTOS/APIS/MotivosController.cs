using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLogicAplicaciones.DataLogicsDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;
using Newtonsoft.Json;

namespace DESCUENTOS.APIS
{
    public class MotivosController : ApiController
    {
        LogicMotivos lgmot = null;

        [HttpPost]
        public string MotivosDesc()
        {
            lgmot = new LogicMotivos();
            string result = JsonConvert.SerializeObject(lgmot.MostrarMotivos());
            return result;
        }

    }
}
