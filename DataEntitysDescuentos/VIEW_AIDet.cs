using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class VIEW_AIDet
    {
        public long ID_MOVDETAJ { get; set; }
        public long ID_MOVCABAJ { get; set; }
        public string LOTE { get; set; }
        public string CODPRODUCTO { get; set; }
        public string DESCRIPCION { get; set; }
        public string BODEGA { get; set; }
        public string UNDMED { get; set; }
        public double CANTIDAD { get; set; }
        public double CANTTEORICA { get; set; }
        public double CANTDIF { get; set; }
        public double VALORp { get; set; }
        public double VALORn { get; set; }
        public string JUSTIFICACION { get; set; }
        public string AJUSTAR { get; set; }


    }
}
