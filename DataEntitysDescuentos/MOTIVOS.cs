using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class MOTIVOS
    {
        [Key]
        public long idmotivos { get; set; }

        public string descMotivo { get; set; }
    }
}
