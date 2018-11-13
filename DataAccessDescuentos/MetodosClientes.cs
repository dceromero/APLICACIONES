using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace  DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosClientes
    {
        ModelAplicacionesDescuentos dbcontext = null;

        public List<View_Clientes> ListarClienteXVendedor(long CEDULA)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.View_Clientes.SqlQuery($"select * from View_Clientes where CEDULA ='{CEDULA}' and estado = '1'").ToList();
        }
    }
}
