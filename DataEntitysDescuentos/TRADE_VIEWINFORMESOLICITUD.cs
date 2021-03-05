using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class TRADE_VIEWINFORMESOLICITUD
    {
        public DateTime FEC_INGRESO { get; set; }
        public string SOLICITANTE { get; set; }
        public string NAMEREGIONAL { get; set; }
        public string Canal { get; set; }
        public string CLIENTE { get; set; }
        public string PRODUCTO { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public string CONCEPTO { get; set; }
        public DateTime FECHA_INIAC { get; set; }
        public DateTime FECHA_FINAC { get; set; }
        public double VALOR { get; set; }
        public  double VENTA_PROMEDIO { get; set; }
        public double VENTA_ESPERADA { get; set; }
        public string JUSTIFICACION { get; set; }

    }
}
