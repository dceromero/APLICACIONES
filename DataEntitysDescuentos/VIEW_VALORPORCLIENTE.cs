using System.ComponentModel.DataAnnotations;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class VIEW_VALORPORCLIENTE
    {
        [Key]
        public long ID_MDDESCUENTO { get; set; }
        public string Material { get; set; }
        public double PORCENDESC { get; set; }
        public int CANT { get; set; }
        public double subtotal { get; set; }
        public double Descuento { get; set; }
        public double total { get; set; }
        public short estado { get; set; }

    }
}
