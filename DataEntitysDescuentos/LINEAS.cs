namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LINEAS
    {
        [Key]
        [StringLength(30)]
        public string cod { get; set; }

        [Required]
        [StringLength(100)]
        public string descripcion { get; set; }
    }
}
