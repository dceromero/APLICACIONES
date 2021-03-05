using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class AI_MOVCABAJUSTE
    {
        public long ID_MOVCABAJ { get; set; }
        public DateTime FECING { get; set; }
        public DateTime FECINV { get; set; }
        public string CODCENTRO { get; set; }
        public long CEDULASUPRV { get; set; }
        public string DOCUMENSAP { get; set; }
        public short APROBJFCD { get; set; }
        public short APROBJFAL { get; set; }
        public short APROBGTSC { get; set; }
        public short APROBGRFI { get; set; }
        public string OBSERVACION { get; set; }
        public long GENERADO { get; set; }
        public short APROBCONTB { get; set; }
        public short APROBGERGEN { get; set; }
        public double CANTSKU { get; set; }
        public double VALTOTALINV { get; set; }
        public virtual List<AI_MOVDETAJUSTE> Ai_MovDetAjuste { get; set; }

    }
}
