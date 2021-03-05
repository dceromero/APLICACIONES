using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class VIEW_VENDEDORES
    {
        public long ID_MCDESCUENTO { get; set; }
        public long CEDULA { get; set; }
        public DateTime FECING { get; set; }
        public DateTime FECINI { get; set; }
        public DateTime FECFIN { get; set; }
        public long CODCLIENTE { get; set; }
        public string RAZSOCCLIENTE { get; set; }
        public short nivel { get; set; }

    }
}
