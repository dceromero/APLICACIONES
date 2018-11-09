namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRODUCTOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTOS()
        {
            MDDESCUENTO = new HashSet<MDDESCUENTO>();
            PRECIOS = new HashSet<PRECIOS>();
        }

        [Key]
        [StringLength(20)]
        public string CODPRODUCTO { get; set; }

        [Required]
        [StringLength(3)]
        public string CODLINPRODUCTO { get; set; }

        public byte CODTIPPRODUCTO { get; set; }

        [Required]
        [StringLength(40)]
        public string DESCRIPCION { get; set; }

        public bool ESTADO { get; set; }

        public double PESUNIMINIMA { get; set; }

        public double VOLUNIMINIMA { get; set; }

        [Required]
        [StringLength(1)]
        public string FIGBONIFICACION { get; set; }

        [Required]
        [StringLength(2)]
        public string GRMATERIALES { get; set; }

        [Required]
        [StringLength(3)]
        public string CODUNIMEDIDA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MDDESCUENTO> MDDESCUENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRECIOS> PRECIOS { get; set; }

        public virtual UNIDADESMEDIDAS UNIDADESMEDIDAS { get; set; }
    }
}
