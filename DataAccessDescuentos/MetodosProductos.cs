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

        public List<View_Productos> ListarProductos(long cedula, long codcliente)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.View_Productos.SqlQuery($"SELECT * FROM func_Productos('{codcliente}')").ToList();
        }

        public List<View_Productos> ListarProductos(PRECIOS pr)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.View_Productos.SqlQuery($"SELECT DESCRIPCION, VALOR FROM VIEW_PRODUCTOS WHERE  OFICINA='{pr.OFICINA}' AND ID_CANAL='{pr.ID_CANAL}' AND GRUPOCLI='{pr.GRUPOCLI}'").ToList();
        }

    }
}
