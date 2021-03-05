
using System.ComponentModel.DataAnnotations;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class TEMP_CLIENTES
    {
        [Key]
        public long idcliente { get; set; }
        public string Codcliente { get; set; }
        public string GrupoCuentas { get; set; }
        public string Razsoccliente { get; set; }
        public string Numruc { get; set; }
        public string Dircliente { get; set; }
        public string Distrito { get; set; }
        public string Numtelefono { get; set; }
        public string Codrespago { get; set; }
        public double Implincredito { get; set; }
        public string Implincreditodisponible { get; set; }
        public double Numfacpendientes { get; set; }
        public string Imptotvencido { get; set; }
        public string Imptotdeuda { get; set; }
        public string Codviapago { get; set; }
        public string Codconpago { get; set; }
        public string Codcendistribucion { get; set; }
        public string Rutero { get; set; }
        public string Flgruta { get; set; }
        public string Grpcliente { get; set; }
        public string Razsocresp { get; set; }
        public string Codbarras { get; set; }
        public string Coddetalle { get; set; }
        public string Secvisita { get; set; }
    }
}
