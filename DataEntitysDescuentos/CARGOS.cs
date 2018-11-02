namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class CARGOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CARGOS()
        {
            //USUARIOS = new HashSet<USUARIOS>();
        }

        [Key]
        [StringLength(10)]
        public string ID_CARGO { get; set; }

        [Required]
        [StringLength(60)]
        public string NAMECARGO { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<USUARIOS> USUARIOS { get; set; }
    }
}
