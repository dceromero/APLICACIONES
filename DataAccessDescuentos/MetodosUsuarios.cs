using System.Collections.Generic;
using System.Linq;
using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosUsuarios
    {
        ModelAplicacionesDescuentos dbcontext = null;

        public long Validar(USUARIOS user)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            long result = dbcontext.Database.SqlQuery<long>($"select dbo.Func_Validar('{user.CEDULA}','{user.CLAVE}')").FirstOrDefault();
            return result;
        }



        public Mensajes PreRegistro(USUARIOS user)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.Database.SqlQuery<Mensajes>($"exec PROC_Preguardo '{user.CEDULA}', '{user.CODIGO}', '{user.NOMBRES}', '{user.APELLIDOS}', '{user.CLAVE}', '{user.JEFEAREA}', '{user.MAIL}', '{user.TELEFONO}', '{user.NIT_EMPRESA}',  '{user.ID_CENCOS}', '{user.ID_CARGO}' ").FirstOrDefault();
        }

        public List<VIEW_Jefes> ListadoDeJefes()
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.VIEW_Jefes.SqlQuery("SELECT * FROM VIEW_Jefes where NIVELUSUARIO>0 ORDER BY NombreCompleto ").ToList();
        }
        
        public VIEW_Jefes User(long cedula)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.VIEW_Jefes.SqlQuery($"select * from VIEW_Jefes where cedula ='{cedula}'").FirstOrDefault();
        }

        public List<VIEW_ENCABEZADO_USUARIO> ListaUsuarios()
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = "select * from VIEW_ENCABEZADO_USUARIO";
            var result = dbcontext.VIEW_ENCABEZADO_USUARIO.SqlQuery(tsql).ToList();
            return result;
        }

        public USUARIOS ConfigUsuario(long cc)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from VIEW_USUARIO where cedula = '{cc}'";
            var result = dbcontext.USUARIOS.SqlQuery(tsql).FirstOrDefault();
            return result;
        }
    }
}
