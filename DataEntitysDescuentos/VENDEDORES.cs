namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VENDEDORES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VENDEDORES()
        {
            CLIENTES_SECTOR = new HashSet<CLIENTES_SECTOR>();
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTES_SECTOR> CLIENTES_SECTOR { get; set; }

        public virtual OFICVENTAS OFICVENTAS { get; set; }

        public virtual REGIONALES REGIONALES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIOS> USUARIOS { get; set; }
    }
}
