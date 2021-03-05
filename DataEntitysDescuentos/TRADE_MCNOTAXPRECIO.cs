using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class TRADE_MCNOTAXPRECIO
    {
        public long ID_MCNOTAXPRECIO { get; set; }
        public byte ID_SOLICITD { get; set; }
        public byte ID_CONCEPTO { get; set; }
        public long ID_TIPONOTA { get; set; }
        public int APROBGER { get; set; }
        public int APROBREV { get; set; }
        public int APROBSOL { get; set; }
        public int APROBCOORTD { get; set; }
        public int APROBGERCOM { get; set; }
        public int APROBJFTRADE { get; set; }
        public long CEDULA { get; set; }
        public DateTime FEC_INGRESO { get; set; }
        public DateTime FEC_DESCARGA { get; set; }
        public string JUSTIFICACION { get; set; }
        public long COD_CLIEN { get; set; }
        public long NIT { get; set; }
        public string NUM_FACTURA { get; set; }
        public bool LEGALIZACION { get; set; }
        public string OBS_GERREG { get; set; }
        public string OBS_REVNEW { get; set; }
        public string OBS_COORTRADE { get; set; }
        public string OBS_JFTRADE { get; set; }
        public string OBS_GERCOM { get; set; }
        public DateTime FECHA_INIAC { get; set; }
        public DateTime FECHA_FINAC { get; set; }
        public double VENTA_PROMEDIO { get; set; }
        public double VENTA_ESPERADA { get; set; }
        public virtual List<TRADE_MDNOTAXPRECIO> listMDNotasXPrecios { get; set; }
    }
}
