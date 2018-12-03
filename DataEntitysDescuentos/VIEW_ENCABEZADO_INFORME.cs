using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class VIEW_ENCABEZADO_INFORME
    {
        public long ID_MCDESCUENTO { get; set; }
        public DateTime FECING { get; set; }
        public DateTime FECINI { get; set; }
        public DateTime FECFIN { get; set; }
        public string DESCRIPCION { get; set; }
        public long CODCLIENTE { get; set; }
        public string RAZSOCCLIENTE { get; set; }
        public string MOTIVO { get; set; }
        public short nivel { get; set; }
        public short estado { get; set; }
    }
}
