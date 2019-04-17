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
            return dbcontext.View_Clientes.SqlQuery($"select * from Func_Clientes('{CEDULA}') where estado = '1'").ToList();
        }

        public VIEW_DETALLECUPO DetalleCupo(long id)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from VIEW_DETALLECUPO CODCLIENTE='{id}'";
            var query = dbcontext.Database.SqlQuery<VIEW_DETALLECUPO>(tsql).FirstOrDefault();
            return query;
        }
    }
}
