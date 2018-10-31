using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataEntitysAplicaciones.DataEntitysDescuentos;
using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;

namespace DESCUENTOS.APIS
{
    public class RolesController : ApiController
    {
        LogicRoles logrol = null;

        [HttpPost]
        public string Guardar(ROLES rol)
        {
            var id = System.Web.HttpContext.Current.Session["id"];
            if (id != null)
            {
                logrol = new LogicRoles();
                return JsonConvert.SerializeObject(logrol.GuardarRol(rol));
            }
            else
            {
                return string.Empty;
            }
        }

        [HttpPost]
        public string ListadoDeRoles()
        {
            var id = System.Web.HttpContext.Current.Session["id"];
            if (id != null)
            {
                logrol = new LogicRoles();
                return JsonConvert.SerializeObject(logrol.ListadoDeRoles());
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
