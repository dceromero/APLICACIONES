using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicUsuarios
    {
        MetodosUsuarios mtuser = null;

        public long ValidarUsuarios(USUARIOS user)
        {
            mtuser = new MetodosUsuarios();
            return mtuser.Validar(user);
        }

        public Mensajes PreRegistro(USUARIOS user)
        {
            mtuser = new MetodosUsuarios();
            return mtuser.PreRegistro(user);
        }

        public List<VIEW_Jefes> ListadoDeJefes()
        {
            mtuser = new MetodosUsuarios();
            return mtuser.ListadoDeJefes();
        }

        public VIEW_Jefes User(long cedula)
        {
            mtuser = new MetodosUsuarios();
            return mtuser.User(cedula);
        }

        public List<VIEW_ENCABEZADO_USUARIO> ListadoUsuarios()
        {
            mtuser = new MetodosUsuarios();
            return mtuser.ListaUsuarios();
        }

        public async Task<string> ConfigUsuarios(long id)
        {
            mtuser = new MetodosUsuarios();
            var mtmail = new MetodosEnviarEmail();
            var usuario = mtuser.ConfigUsuario(id);
            var result = await mtmail.EnviarMensaje(usuario.MAIL, usuario.CLAVE);
            return result;
        }
    }
}
