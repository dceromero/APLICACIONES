using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioDescuentos
{
    class Program
    {
        static void Main(string[] args)
        {
            string digito = "";
            for (var i = 0; i < args.Length; i++)
            {
                digito = args[i];
            }
            digito = "6";
                switch (digito)
                {
                    case "1":
                        MetodosPrecios mt = new MetodosPrecios();
                        Console.WriteLine(mt.Guardar());
                        break;
                    case "2":
                        MetodosProductos mtp = new MetodosProductos();
                        foreach (string x in mtp.Guardar())
                        {
                            Console.WriteLine(x);
                        }
                        break;
                    case "3":
                        MetodosClienteSector mtcs = new MetodosClienteSector();
                        Console.WriteLine(mtcs.Guardar());
                        break;
                    case "4":
                        MetodosClientes mtcg = new MetodosClientes();
                        foreach (string x in mtcg.Guardar())
                        {
                            Console.WriteLine(x);
                        }
                        break;
                    case "5":
                        Console.WriteLine("Digite el Codigo del cliente");
                        string codcliente = Console.ReadLine();
                        MetodosClientes mtcg1 = new MetodosClientes();
                        foreach (string x in mtcg1.Guardar(codcliente))
                        {
                            Console.WriteLine(x);
                        }
                        break;
                    case "6":
                        MetodosDescuentos mtdesc = new MetodosDescuentos();
                        var algo = mtdesc.Guardar();
                        break;
                    default:
                        break;
                }
            Environment.Exit(0);
        }
    }
}
