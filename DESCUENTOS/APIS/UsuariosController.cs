using System;
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
    }
}
