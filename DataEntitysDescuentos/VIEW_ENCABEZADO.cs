using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class VIEW_ENCABEZADO
    {
        public VIEW_ENCABEZADO()
        {
            VIEW_VALORPORCLIENTE = new HashSet<VIEW_VALORPORCLIENTE>();
        }
        [Key]
        public long ID_MCDESCUENTO { get; set; }
        public long CODCLIENTE { get; set; }
        public string DESCRIPCION { get; set; }
        public string RAZSOCCLIENTE { get; set; }
        public string NAMEOFICVENTA { get; set; }
        public DateTime FECINI { get; set; }
        public DateTime FECFIN { get; set; }
        public string DESCMOTIVO { get; set; }
        public string MOTIVO { get; set; }
        public double subtotal { get; set; }
        public double Descuento { get; set; }
        public double total { get; set; }
        public short nivel { get; set; }
        public short estado { get; set; }
        public virtual ICollection<VIEW_VALORPORCLIENTE> VIEW_VALORPORCLIENTE { get; set; }
    }
}
