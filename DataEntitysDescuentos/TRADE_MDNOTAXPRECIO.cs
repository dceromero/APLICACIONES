using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class TRADE_MDNOTAXPRECIO
    {
        public long ID_MDNOTACOMERCIAL { get; set; }
        public long ID_MCNOTAXPRECIO { get; set; }
        public string CODPRODUCTO { get; set; }
        public double VALOR { get; set; }
    }
}
