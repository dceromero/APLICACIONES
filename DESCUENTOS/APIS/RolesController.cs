using DataEntitysAplicaciones.DataEntitysDescuentos;
using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
using System.Web.Http;

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
                return JsonConvert.SerializeObject(logrol.GuardarRol(rol), Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
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
                return JsonConvert.SerializeObject(logrol.ListadoDeRoles(), Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
