using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicRegionales
    {
        MetodosRegionales mtreg = null;
        public List<REGIONALES> ListadoRegionales()
        {
            mtreg = new MetodosRegionales();
            return mtreg.ListadoRegionales();
        }
    }
}
