using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class TRADE_VIEWNOTA
    {
        public long ID_MCNOTACOMERCIAL { get; set; }
        public DateTime FEC_INGRESO { get; set; }
        public DateTime FEC_DESCARGA { get; set; }
        public long CEDULA { get; set; }
        public string solicitante { get; set; }
        public string RESPONSABLE { get; set; }
        public string cliente { get; set; }
        public string NUM_FACTURA { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public string CONCEPTO { get; set; }
        public string JUSTIFICACION { get; set; }
        public int APROBCOORTD { get; set; }
        public int APROBGERCOM { get; set; }
        public int APROBGERREG { get; set; }
        public int APROBJFTRADE { get; set; }
        public int APROBREV { get; set; }
        public int APROBSOL { get; set; }
        public double VALOR { get; set; }
        public string OBSERVACION { get; set; }
        public bool NOTI { get; set; }
        public string DOCSAP { get; set; }
        public  byte ESTADO { get; set; }
        public bool LEGALIZACION { get; set; }
        public DateTime FECHA_INIAC { get; set; }
        public DateTime FECHA_FINAC { get; set; }
        public double VENTA_PROMEDIO { get; set; }
        public double VENTA_ESPERADA { get; set; }
        public virtual TRADE_LEGALIZACION datosLegalizacion { get; set; }
        public virtual List<TRADE_MDNOTAXPRECIO> listDetail { get; set; }

    }
}
