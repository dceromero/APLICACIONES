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
    }
}
