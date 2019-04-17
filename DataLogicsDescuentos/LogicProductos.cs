using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;
using DataAccessAplicaciones.DataAccessDescuentos;
namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicProductos
    {

        MetodosProductos mtproduct = null;

       public List<View_Productos> productos(long cedula, long codcliente)
        {
            mtproduct = new MetodosProductos();
            return mtproduct.ListarProductos(cedula, codcliente);
        }

        public List<View_Productos> productos(PRECIOS pr)
        {
            mtproduct = new MetodosProductos();
            return mtproduct.ListarProductos(pr);
        }
    }
}
