using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicRoles
    {
        MetodosRoles mtrol = null;

        public int GuardarRol(ROLES rol)
        {
            mtrol = new MetodosRoles();
            return mtrol.GuardarRoles(rol);
        }

        public List<ROLES> ListadoDeRoles()
        {
            mtrol = new MetodosRoles();
            return mtrol.ListadoRoles();
        }
    }
}
