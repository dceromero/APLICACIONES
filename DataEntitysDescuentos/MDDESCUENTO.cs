namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MDDESCUENTO")]
    public partial class MDDESCUENTO
    {
        [Key]
        public long ID_MDDESCUENTO { get; set; }

        public long ID_MCDESCUENTO { get; set; }

        [Required]
        [StringLength(20)]
        public string CODPRODUCTO { get; set; }

        public byte PORCENDESC { get; set; }

        public byte VERIFICA1 { get; set; }

        public byte VERIFICA2 { get; set; }

        public byte VERIFICA3 { get; set; }

        public byte APRUEBA1 { get; set; }

        public byte APRUEBA2 { get; set; }

        [Required]
        public string OBS { get; set; }

        public virtual MCDESCUENTOS MCDESCUENTOS { get; set; }

        public virtual PRODUCTOS PRODUCTOS { get; set; }
    }
}
