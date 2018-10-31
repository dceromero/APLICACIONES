using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class VIEW_Permisos
    {
        [Key]
        public short id_permiso { get; set; }

        public string namerol { get; set; }

        public string namesubmenu { get; set; }

    }
}
