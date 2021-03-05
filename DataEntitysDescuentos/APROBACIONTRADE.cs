using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class APROBACIONTRADE
    {
        public long ID_MDDESCUENTO { get; set; }
        public DateTime FECING { get; set; }
        public string NAMECOMPLETE { get; set; }
        public string OFICINA { get; set; }
        public string CANAL { get; set; }
        public string RAZSOCCLIENTE { get; set; }
        public DateTime FECINI { get; set; }
        public DateTime FECFIN { get; set; }
        public string PRODUCTO { get; set; }
        public double PORCENDESC { get; set; }
        public int CANT { get; set; }
        public string DESCRIPCION { get; set; }
        public string MOTIVO { get; set; }
    }
}
