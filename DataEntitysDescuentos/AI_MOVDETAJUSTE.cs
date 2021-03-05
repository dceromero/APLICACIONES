using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class AI_MOVDETAJUSTE
    {
        public long ID_MOVDETAJ { get; set; }
        public long ID_MOVCABAJ { get; set; }
        public long NRO_REGISTRO { get; set; }
        public string CODPRODUCTO { get; set; }
        public string DESCRIPCION { get; set; }
        public string BODEGA { get; set; }
        public string UNDMED { get; set; }
        public double CANTIDAD { get; set; }
        public double VALOR { get; set; }
        public string JUSTIFICACION { get; set; }
        public double CANTTEORICA { get; set; }
        public string LOTE { get; set; }
        public double VALORNEG { get; set; }
        public string AJUSTAR { get; set; }
    }
}
