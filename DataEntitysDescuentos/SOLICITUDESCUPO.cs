using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class SOLICITUDESCUPO
    {
        public long IDSOL { get; set; }

        public short TIPOSOL { get; set; }

        public long CODCLIENTE { get; set; }

        public long CEDULA { get; set; }

        public DateTime FECSOL { get; set; }

        public decimal CUPOSOLICITADO { get; set; }

        public decimal CUPOAPROBADO { get; set; }

        public DateTime VIGENCIA { get; set; }

        public short APROBJF { get; set; }

        public short APROBGC { get; set; }

        public short APROBGV { get; set; }

        public short APROBCT { get; set; }

        public short APROBGF { get; set; }

        public short APROBGG { get; set; }

        public string OBS { get; set; }

        public short NOTI { get; set; }

        public decimal CUPOENCARTERA { get; set; }

        public decimal CUPOVENCIDO { get; set; }

        public decimal CUPODISPONIBLE { get; set; }

        public short DIASVEN { get; set; }

        public decimal hipoteca { get; set; }

        public decimal pignoracion { get; set; }

    }
}
