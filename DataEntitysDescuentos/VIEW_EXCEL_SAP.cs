using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class VIEW_EXCEL_SAP
    {
        public short ID_CANAL{ get; set; }
        public long ID_MCDESCUENTO { get; set; }
        public long CODCLIENTE { get; set; }
        public string RAZSOCCLIENTE { get; set; }
        public string producto { get; set; }
        public int? vacio1 { get; set; }
        public int? vacio2 { get; set; }
        public int? vacio3 { get; set; }
        public double PORCENDESC { get; set; }
        public string simbolo { get; set; }
        public string FECINI { get; set; }
        public string FECFIN { get; set; }
        public int CANT { get; set; }
        public string material { get; set; }
    }
}
