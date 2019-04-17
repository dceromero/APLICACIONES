using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class VIEW_HEADER_CANAL
    {
        public long CEDULA { get; set; }
        public string VENDEDOR { get; set; }
        public long ID_MCDCTOCANAL { get; set; }
        public string NAMEOFICVENTA { get; set; }
        public string NAMECANALES { get; set; }
        public string GRPNOMBRE { get; set; }
        public DateTime FECING { get; set; }
        public DateTime FECINI { get; set; }
        public DateTime FECFIN { get; set; }
        public string DESCMOTIVO { get; set; }
        public string JUSTIFICACION { get; set; }
        public double SUBTOTAL { get; set; }
        public double DESCUENTO { get; set; }
        public double TOTAL { get; set; }
        public short nivel { get; set; }
        public short estado { get; set; }
        public virtual ICollection<VIEW_VALORPORCANAL> VIEW_VALORPORCANAL { get; set; }
    }
}
