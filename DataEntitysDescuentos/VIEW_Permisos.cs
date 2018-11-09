namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VIEW_Permisos
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short ID_PERMISO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string NAMEROL { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string NAMESUBMENU { get; set; }
    }
}
