using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class VIEW_AIINFORMEESTADOS
    {
        public long ID_MOVCABAJ { get; set; }
        public DateTime FECING { get; set; }
        public DateTime FECINV { get; set; }
        public string CENTRO { get; set; }
        public string BODEGA { get; set; }
        public string SUPERVISOR { get; set; }
        public short APROBJFCD { get; set; }
        public short APROBJFAL { get; set; }
        public short APROBCONTB { get; set; }
        public short APROBGTSC { get; set; }
        public short APROBGRFI { get; set; }
        public short APROBGERGEN { get; set; }

    }
}
