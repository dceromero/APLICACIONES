using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class View_Clientes
    {
        public string RAZSOCCLIENTE { get; set; }
        [Key]
        public long CODCLIENTE { get; set; }

        public long CEDULA { get; set; }

        public short ID_CANAL { get; set; }

        public string COD_VENDEDOR { get; set; }

        public bool ESTADO { get; set; }

    }
}
