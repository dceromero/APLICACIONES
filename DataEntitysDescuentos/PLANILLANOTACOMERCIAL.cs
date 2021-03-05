using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class PLANILLANOTACOMERCIAL
    {
        public long documento { get; set; }
        public string docventa { get; set; }
        public string codorganizacion { get; set; }
        public short id_canal { get; set; }
        public string codsector { get; set; }
        public long solicitante { get; set; }
        public string motivo { get; set; }
        public string bloqueofactura { get; set; }
        public string concepto { get; set; }
        public long posicion { get; set; }
        public string codproducto { get; set; }
        public string cantidad { get; set; }
        public double valor { get; set; }
        public string centro { get; set; }
        public string fecfact { get; set; }
        public string tipofactura { get; set; }
        public int aprobgerreg { get; set; }
        public DateTime fec_ingreso { get; set; }
        public DateTime fec_descarga { get; set; }
        public bool noti { get; set; }

    }
}
