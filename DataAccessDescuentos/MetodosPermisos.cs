using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosPermisos
    {
        ModelAplicacionesDescuentos dbcontext = null;

        public PERMISOS GuardarPermisos(PERMISOS per)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.PERMISOS.SqlQuery($"exec PROC_AsignacionPermiso '{per.ID_ROL}', '{per.ID_SUBMENU}'").FirstOrDefault();
        }

        public List<VIEW_Permisos> ListaPermisos()
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.VIEW_Permisos.SqlQuery("select * from VIEW_Permisos").ToList();
        }


    }
}
