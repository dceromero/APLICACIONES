using System.Collections.Generic;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicEmpresas
    {
        MetodosEmpresas mtempre = null;

        public List<EMPRESAS> ListaDeEmpresas()
        {
            mtempre = new MetodosEmpresas();
            return mtempre.LitadoDeEmpresas();
        }
    }
}
