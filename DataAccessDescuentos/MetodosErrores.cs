using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public static class MetodosErrores
    {

        public static void GuardarError(ERRORES error)
        {
           var dbContext = new ModelAplicacionesDescuentos();
            dbContext.ERRORES.Add(error);
            dbContext.SaveChanges();
        }
    }
}
