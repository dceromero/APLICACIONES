using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class VIEW_CANAl_EXCEL_SAP
    {
        public long ID_MCDCTOCANAL { get; set; }

        public string ORGANIZACION { get; set; }

        public short ID_CANAL { get; set; }

        public string ID_OFICVENTA { get; set; }

        public string GRPCLIENTE { get; set; }

        public string producto { get; set; }

        public int? vacio1 { get; set; }
        public int? vacio2 { get; set; }
        public int? vacio3 { get; set; }

        public double PORCENDCTO { get; set; }

        public string simbolo { get; set; }

        public DateTime fecini { get; set; }

        public DateTime fecfin { get; set; }

        public int cant { get; set; }

        public string material { get; set; }

    }
}
