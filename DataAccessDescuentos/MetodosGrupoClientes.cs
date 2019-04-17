using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosGrupoClientes
    {
        ModelAplicacionesDescuentos dbcontext = null;

        public List<GRUPOCLIENTES> ListadoGrupoClientes(short idc)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.Database.SqlQuery<GRUPOCLIENTES>($"select * from GRUPOCLIENTES WHERE ID_CANAL ='{idc}' ORDER BY GRPNOMBRE").ToList();
        }
    }
}
