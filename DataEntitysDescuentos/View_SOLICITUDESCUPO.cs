using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class View_SOLICITUDESCUPO
    {
        public long IDSOL { get; set; }
        public short TIPOSOL { get; set; }
        public string TSOL { get; set; }
        public string cliente { get; set; }
        public string VENDEDOR { get; set; }
        public long CODRESPAGO { get; set; }
        public string RAZSOCRESP { get; set; }
        public double CUPOASIGNADO { get; set; }
        public double CUPOSOLICITADO { get; set; }
        public DateTime FECSOL { get; set; }
        public DateTime VIGENCIA { get; set; }
        public double CUPODISPONIBLE { get; set; }
        public double CUPOENCARTERA { get; set; }
        public string OBS { get; set; }
        public double CUPOVENCIDO { get; set; }
        public double DIASVEN { get; set; }
        public double hipoteca { get; set; }
        public double pignoracion { get; set; }
    }
}
