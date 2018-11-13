using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosProductos
    {
        ModelAplicacionesDescuentos dbcontext = null;

        public List<View_Productos> ListarProductos()
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.View_Productos.SqlQuery("select CODPRODUCTO, CONCAT(CODPRODUCTO,'-',DESCRIPCION) AS DESCRIPCION from PRODUCTOS WHERE ESTADO = 1 ").ToList();
        }
           
    }
}
