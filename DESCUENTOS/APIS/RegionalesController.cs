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
    public class RegionalesController : ApiController
    {
        LogicRegionales logreg = null;

        public string ListadoRegionales()
        {
            logreg = new LogicRegionales();
            return JsonConvert.SerializeObject(logreg.ListadoRegionales());
        }
    }
}
