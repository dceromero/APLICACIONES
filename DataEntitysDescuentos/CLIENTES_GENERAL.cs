namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CLIENTES_GENERAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENTES_GENERAL()
        {
            MCDESCUENTOS = new HashSet<MCDESCUENTOS>();
        }

        public long NIT { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CODCLIENTE { get; set; }

        [Required]
        [StringLength(4)]
        public string GRUPO_CUENTAS { get; set; }

        [Required]
        [StringLength(60)]
        public string RAZSOCCLIENTE { get; set; }

        [Required]
        [StringLength(30)]
        public string NUMRUC { get; set; }

        [Required]
        [StringLength(70)]
        public string DIRCLIENTE { get; set; }

        [Required]
        [StringLength(30)]
        public string DISTRITO { get; set; }

        public long NUMTELEFONO { get; set; }

        public long CODRESPAGO { get; set; }

        public double CUPOCREDITO { get; set; }

        [Required]
        [StringLength(4)]
        public string CODCONPAGO { get; set; }

        [Required]
        [StringLength(2)]
        public string GRPCLIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MCDESCUENTOS> MCDESCUENTOS { get; set; }
    }
}
