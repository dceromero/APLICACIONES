using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicOficinas
    {

        MetodosOficVentas mtofi = null;
        public List<OFICVENTAS> ListadoOfixReg(string idr)
        {
            mtofi = new MetodosOficVentas();
            return mtofi.ListadoOfixReg(idr);
        }
    }
}
