using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicClientes
    {
        MetodosClientes mtclient = null;

        public List<View_Clientes> ListarClientesXVendedor(long CEDULA)
        {
            mtclient = new MetodosClientes();
            return mtclient.ListarClienteXVendedor(CEDULA);
        }
    }
}
