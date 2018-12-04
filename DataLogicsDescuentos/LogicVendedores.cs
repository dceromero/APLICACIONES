using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicVendedores
    {
        MetodosVendedores mtvend = null;

        public List<VENDEDORES> CodigosVendedores()
        {
            mtvend = new MetodosVendedores();
            return mtvend.CodigosVendedores();
        }
    }
}
