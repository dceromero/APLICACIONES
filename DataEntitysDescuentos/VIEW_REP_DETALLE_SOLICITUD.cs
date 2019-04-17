using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class VIEW_REP_DETALLE_SOLICITUD
    {
        public string TPSOL { get; set; }

        public DateTime FECING { get; set; }

        public string NAMEOFICVENTA { get; set; }

        public long NIT { get; set; }

        public string RAZSOCCLIENTE { get; set; }

        public DateTime FECINI { get; set; }

        public DateTime FECFIN { get; set; }

        public string MATERIAL { get; set; }

        public  double PORCENDESC { get; set; }

        public int CANT { get; set; }

        public string DESCMOTIVO { get; set; }

        public string JUSTMOT { get; set; }

        public double VALOR { get; set; }

        public double SUBTOTAL { get; set; }

        public double DESCUENTO { get; set; }

        public double TOTAL { get; set; }

        public short ESTADO { get; set; }

        public string OBS { get; set; }


    }
}
