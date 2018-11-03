using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class VIEW_Jefes
    {
        [Key]
        public long CEDULA { get; set; }
        public string NombreCompleto { get; set; }
        public string MAIL { get; set; }
        public short NIVELUSUARIO { get; set; }
    }
}
