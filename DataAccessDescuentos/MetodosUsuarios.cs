using System.Linq;
using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosUsuarios
    {
        ModelAplicacionesDescuentos dbcontext = null;

        public int Validar(USUARIOS user)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            int result = dbcontext.Database.SqlQuery<int>($"select dbo.Func_Validar('{user.CEDULA}','{user.CLAVE}')").FirstOrDefault();
            return result;
        }
    }
}
