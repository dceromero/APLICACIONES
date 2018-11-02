namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CENCOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CENCOS()
        {
           // USUARIOS = new HashSet<USUARIOS>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID_CENCOS { get; set; }

        [Required]
        [StringLength(100)]
        public string NAMECENCOS { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<USUARIOS> USUARIOS { get; set; }
    }
}
