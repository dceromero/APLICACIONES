using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class VIEW_VALORPORCANAL
    {
        public long ID_MDDCTOCANAL { get; set; }
        public string Material { get; set; }
        public byte PORCENDCTO { get; set; }
        public int CANT { get; set; }
        public double subtotal { get; set; }
        public double Descuento { get; set; }
        public double total { get; set; }
        public short estado { get; set; }
    }
}
