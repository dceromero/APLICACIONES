using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{


    public class AI_APROBACIONMASIVA
    {
        public long ID_MOVCABAJ { get; set; }
        public DateTime FECINV { get; set; }
        public string CD { get; set; }
        public double VALORTOTAL { get; set; }
        public string BODEGA { get; set; }
        public string RESPONSABLE { get; set; }
        public short APROBGTSC { get; set; }
        public short APROBGRFI { get; set; }
        public short APROBGERGEN { get; set; }
    }
}
