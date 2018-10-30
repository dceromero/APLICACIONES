namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class VENDEDORES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VENDEDORES()
        {
            USUARIOS = new HashSet<USUARIOS>();
        }

        [Key]
        [StringLength(5)]
        public string COD_VENDEDOR { get; set; }

        [Required]
        [StringLength(30)]
        public string NAMEVENDEDOR { get; set; }

        [Required]
        [StringLength(5)]
        public string ID_REGIONAL { get; set; }

        [Required]
        [StringLength(8)]
        public string ID_OFICVENTA { get; set; }

        public short ID_CANAL { get; set; }

        public bool ESTADO { get; set; }

        public virtual CANALES CANALES { get; set; }

        public virtual OFICVENTAS OFICVENTAS { get; set; }

        public virtual REGIONALES REGIONALES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIOS> USUARIOS { get; set; }
    }
}
