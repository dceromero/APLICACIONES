﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class View_Productos
    {
        [Key]
        public string CODPRODUCTO { get; set; }
        
        public string DESCRIPCION { get; set; }

    }
}
