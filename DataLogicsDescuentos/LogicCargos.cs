using System.Collections.Generic;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicCargos
    {
        MetodosCargos mtcargos = null;

        public List<CARGOS> ListadoDeCargos()
        {
            mtcargos = new MetodosCargos();
            return mtcargos.ListadoCargos();
        }
    }
}
