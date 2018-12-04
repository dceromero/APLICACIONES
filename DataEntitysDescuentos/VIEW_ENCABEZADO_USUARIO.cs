using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class VIEW_ENCABEZADO_USUARIO
    {
        [Key]
        public long CEDULA { get; set; }
        public string NAMECOMPLETO { get; set; }
        public string COD_VENDEDOR { get; set; }
        public bool ESTADO { get; set; }
    }
}
