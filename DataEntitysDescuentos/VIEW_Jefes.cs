namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VIEW_Jefes
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CEDULA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(61)]
        public string NombreCompleto { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string MAIL { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short NIVELUSUARIO { get; set; }
    }
}
