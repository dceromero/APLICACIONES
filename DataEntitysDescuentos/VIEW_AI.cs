using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class VIEW_AI
    {
        public DateTime FECING { get; set; }
        public DateTime FECINV { get; set; }
        public string DOCUMENSAP { get; set; }
        public string NOMBRE { get; set; }
        public long ID_MOVCABAJ { get; set; }
        public string OBSERVACION { get; set; }
        public string CD { get; set; }
        public double CANTSKU { get; set; }
        public double VALTOTALINV { get; set; }
        public virtual List<VIEW_AIDet> detAI { get; set; }
        public virtual List<AI_DOCSAP> listDocSap { get; set; }
    }

}
