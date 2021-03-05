using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class VIEW_ENCABEZADO_INFORME_CANAL
    {
        public string VENDEDOR { get; set; }

        public long ID_MCDCTOCANAL { get; set; }

        public DateTime FECING { get; set; }

        public DateTime FECINI { get; set; }

        public DateTime FECFIN { get; set; }

        public string OFICINA { get; set; }

        public string CANAL { get; set; }

        public string GRPCLIENTES { get; set; }

        public string DESCMOTIVO { get; set; }

        public short NIVEL { get; set; }

        public short ESTADO { get; set; }
        
    }
}
