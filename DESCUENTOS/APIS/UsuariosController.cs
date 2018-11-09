using System;
using System.Web;
using System.Web.Http;
using DataEntitysAplicaciones.DataEntitysDescuentos;
using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
namespace DESCUENTOS.APIS
{
    public class UsuariosController : ApiController
    {

        LogicUsuarios loguser = null;


        [HttpPost]
        public string Validar(USUARIOS user)
        {
            loguser = new LogicUsuarios();
            long result = loguser.ValidarUsuarios(user);
            System.Web.HttpContext.Current.Session["id"] = (result >= 1) ? result.ToString() : null;
            return JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string PreRegistro(USUARIOS user)
        {
            loguser = new LogicUsuarios();
            return JsonConvert.SerializeObject(loguser.PreRegistro(user), Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        [HttpPost]
        public string ListadoDeJefes()
        {
            loguser = new LogicUsuarios();
            return JsonConvert.SerializeObject(loguser.ListadoDeJefes(), Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        [HttpPost]
        public string Usuario()
        {
            var id = HttpContext.Current.Session["id"];
            if (id != null)
            {
                loguser = new LogicUsuarios();
                return JsonConvert.SerializeObject(loguser.User(long.Parse(id.ToString())), Formatting.Indented, new JsonSerializerSettings
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
