using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAplicaciones.DataAccessDescuentos;

namespace ConsoleAdminVentas
{
    class Program
    {
        static void Main(string[] args)
        {
            MetodosLegalizacion legalizacion = new MetodosLegalizacion();
            legalizacion.provicionLegalizacion();
            Console.WriteLine("Proceso Terminado");
            Console.ReadKey();
        }
    }
}
