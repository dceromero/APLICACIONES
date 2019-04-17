using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicGrupoClientes
    {
        MetodosGrupoClientes mtgrpclient = null;

        public List<GRUPOCLIENTES> ListadoCanales(short idc)
        {
            mtgrpclient = new MetodosGrupoClientes();
            return mtgrpclient.ListadoGrupoClientes(idc);
        }
    }
}
