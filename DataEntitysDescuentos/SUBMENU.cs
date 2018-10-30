namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SUBMENU")]
    public partial class SUBMENU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUBMENU()
        {
            PERMISOS = new HashSet<PERMISOS>();
        }

        [Key]
        public short ID_SUBMENU { get; set; }

        public short? ID_MENU { get; set; }

        [Required]
        [StringLength(30)]
        public string NAMESUBMENU { get; set; }

        [Required]
        [StringLength(50)]
        public string URLSUBMENU { get; set; }

        [Required]
        [StringLength(30)]
        public string ICOSUBMENU { get; set; }

        public virtual MENU MENU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERMISOS> PERMISOS { get; set; }
    }
}
