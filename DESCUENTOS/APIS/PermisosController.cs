﻿using System.Web.Http;
using DataEntitysAplicaciones.DataEntitysDescuentos;
using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;

namespace DESCUENTOS.APIS
{
    public class PermisosController : ApiController
    {
        LogicPermisos logper = null;

        [HttpPost]
        public string GuardarPermisos(PERMISOS per)
        {
            var id = System.Web.HttpContext.Current.Session["id"];
            if (id != null)
            {
                logper = new LogicPermisos();
                return JsonConvert.SerializeObject(logper.GuardarPermisos(per));
            }
            else
            {
                return string.Empty;
            }

        }

        [HttpPost]
        public string ListadoDePermisos()
        {
            var id = System.Web.HttpContext.Current.Session["id"];
            if (id != null)
            {
                logper = new LogicPermisos();
                return JsonConvert.SerializeObject(logper.ListadoPermisos());
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
