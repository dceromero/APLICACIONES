using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;
using DataAccessAplicaciones.DataAccessDescuentos;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicPermisos
    {
        MetodosPermisos mtper = null;

        public PERMISOS GuardarPermisos(PERMISOS per)
        {
            mtper = new MetodosPermisos();
            return mtper.GuardarPermisos(per);
        }

        public List<VIEW_Permisos> ListadoPermisos()
        {
            mtper = new MetodosPermisos();
            return mtper.ListaPermisos();
        }
    }
}
