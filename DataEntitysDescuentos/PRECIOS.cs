namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRECIOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRECIOS()
        {
            HISTORICOPRECIOS = new HashSet<HISTORICOPRECIOS>();
        }

        [Key]
        public int ID_PRECIO { get; set; }

        [Required]
        [StringLength(20)]
        public string CODPRODUCTO { get; set; }

        public short ID_CANAL { get; set; }

        [Required]
        [StringLength(4)]
        public string CODCONPAGO { get; set; }

        [Required]
        [StringLength(4)]
        public string CODORGANIZACION { get; set; }

        [Required]
        [StringLength(4)]
        public string OFICINA { get; set; }

        [Required]
        [StringLength(2)]
        public string GRUPOCLI { get; set; }

        public double VALOR { get; set; }

        [Required]
        [StringLength(3)]
        public string CODUNIMEDIDA { get; set; }

        public virtual CANALES CANALES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORICOPRECIOS> HISTORICOPRECIOS { get; set; }

        public virtual PRODUCTOS PRODUCTOS { get; set; }

        public virtual UNIDADESMEDIDAS UNIDADESMEDIDAS { get; set; }
    }
}
