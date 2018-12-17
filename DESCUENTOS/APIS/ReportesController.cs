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
    public class ReportesController : ApiController
    {
        LogicReportes lgrept = null;

        [HttpPost]
        public string DetalleSolicitud(DateTime fecini, DateTime fecfin)
        {
            lgrept = new LogicReportes();
            string result = JsonConvert.SerializeObject(lgrept.DetalleSolicitud(fecini, fecfin));
            return result;
        }

    }
}
