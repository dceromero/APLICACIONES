namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class REGIONALES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public REGIONALES()
        {
            VENDEDORES = new HashSet<VENDEDORES>();
        }

        [Key]
        [StringLength(5)]
        public string ID_REGIONAL { get; set; }

        [Required]
        [StringLength(50)]
        public string NAMEREGIONAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VENDEDORES> VENDEDORES { get; set; }
    }
}
