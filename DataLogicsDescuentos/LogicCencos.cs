using System.Collections.Generic;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicCencos
    {
        MetodosCencos mtcencos = null;

        public List<CENCOS> ListadoDeCentroCosto()
        {
            mtcencos = new MetodosCencos();
            return mtcencos.ListadoDeCentroCostos();
        }
    }
}
