using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class TRADE_MDLEGALIZACION
    {
        public long ID_MDLEGALIZACION { get; set; }
        public long ID_LEGALIZA { get; set; }
        public string CODPRODUCTO { get; set; }
        public double VALOR { get; set; }
    }
}
