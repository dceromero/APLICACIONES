using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class REPAADMONVENTAS
    {
        public DateTime FECING { get; set; }
        public string CODOFICINA { get; set; }
        public short CODCANAL { get; set; }
        public long CEDULA { get; set; }
        public string SUPERVISOR { get; set; }
        public string CODUSUARIORAZ { get; set; }
        public long CODCLIENTE { get; set; }
        public string RAZSOCCLIENTE { get; set; }
        public string FECINI { get; set; }
        public string FECFIN { get; set; }
        public string CODPRODUCTO { get; set; }
        public string DESCRIPCION { get; set; }
        public double PORCENDESC { get; set; }
        public int CANT { get; set; }
        public short nivel { get; set; }
        public byte DONWLOADEXCEL { get; set; }
    }
}
