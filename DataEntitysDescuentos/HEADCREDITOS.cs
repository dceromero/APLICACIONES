using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class HEADCREDITOS
    {
        public long IDSOL { get; set; }

        public DateTime FECSOL { get; set; }

        public string NOMBRE { get; set; }

        public string TSOL { get; set; }

        public string CLIENTE { get; set; }

        public DateTime VIGENCIA { get; set; }

        public double CUPOSOLICITADO { get; set; }

        public double CUPOAPROBADO { get; set; }

        public int ESTADO { get; set; }
    }
}
