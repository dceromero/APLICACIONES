namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class OFICVENTAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OFICVENTAS()
        {
            VENDEDORES = new HashSet<VENDEDORES>();
        }

        [Key]
        [StringLength(8)]
        public string ID_OFICVENTA { get; set; }

        [StringLength(30)]
        public string NAMEOFICVENTA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VENDEDORES> VENDEDORES { get; set; }
    }
}
