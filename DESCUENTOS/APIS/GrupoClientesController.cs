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
    public class GrupoClientesController : ApiController
    {
        LogicGrupoClientes logGrpClient = null;

        [HttpPost]
        public string ListaGruClient(short id)
        {
            logGrpClient = new LogicGrupoClientes();
            return JsonConvert.SerializeObject(logGrpClient.ListadoCanales(id));
        }
        
    }
}
