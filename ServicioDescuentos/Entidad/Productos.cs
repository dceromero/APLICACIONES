using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace ServicioDescuentos
{
    public class Productos
    {
        public Result Resultado { get; set; }
    }

    public class Result
    {
        public List<TEMP_PRODUCTOS> item { get; set; }
    } 
}
