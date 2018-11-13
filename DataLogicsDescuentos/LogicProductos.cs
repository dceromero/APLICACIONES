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

       public List<View_Productos> productos()
        {
            mtproduct = new MetodosProductos();
            return mtproduct.ListarProductos();
        }
    }
}
