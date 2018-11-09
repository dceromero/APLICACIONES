namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UNIDADESMEDIDAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UNIDADESMEDIDAS()
        {
            PRECIOS = new HashSet<PRECIOS>();
            PRODUCTOS = new HashSet<PRODUCTOS>();
        }

        [Key]
        [StringLength(3)]
        public string CODUNIMEDIDA { get; set; }

        [Required]
        [StringLength(30)]
        public string DESCRIPCION { get; set; }

        public double CONVERSION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRECIOS> PRECIOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTOS> PRODUCTOS { get; set; }
    }
}
