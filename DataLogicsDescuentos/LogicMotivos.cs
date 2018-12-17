using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicMotivos
    {
        MetodosMotivos mtmot = null;
        public List<MOTIVOS> MostrarMotivos()
        {
            mtmot = new MetodosMotivos();
            return mtmot.MostrarMotivos();
        }
    }
}
