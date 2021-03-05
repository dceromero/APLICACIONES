using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class TRADE_INFORMEREVENEW
    {
        public DateTime fec_ingreso { get; set; }
        public string solicitante { get; set; }
        public string aprobador { get; set; }
        public string concepto { get; set; }
        public string cliente { get; set; }
        public string oficina { get; set; }
        public string canal { get; set; }
        public string producto { get; set; }
        public double valor { get; set; }
        public string num_factura { get; set; }
        public string tiposolicitud { get; set; }
        public string docsap { get; set; }
        public byte ESTADO { get; set; }

    }
}
