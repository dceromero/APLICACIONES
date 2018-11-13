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
    public class SolicitudesController : ApiController
    {
        LogicSolicitudes lgsolict = null;

        [HttpPost]
        public string ListarTiposSolicitudes()
        {
            lgsolict = new LogicSolicitudes();
            return JsonConvert.SerializeObject(lgsolict.ListarTiposSolicitudes());
        }
    }
}
