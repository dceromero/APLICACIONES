namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MCDESCUENTOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MCDESCUENTOS()
        {
            MDDESCUENTO = new HashSet<MDDESCUENTO>();
        }

        [Key]
        public long ID_MCDESCUENTO { get; set; }

        public byte ID_SOLICITD { get; set; }

        public long CODCLIENTE { get; set; }

        public DateTime FECING { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECINI { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECFIN { get; set; }

        [Required]
        public string MOTIVO { get; set; }

        public long idmotivos { get; set; }

        public long CEDULA { get; set; }

        public virtual CLIENTES_GENERAL CLIENTES_GENERAL { get; set; }

        public virtual TIPOSOLICITUD TIPOSOLICITUD { get; set; }

        public virtual ICollection<MDDESCUENTO> MDDESCUENTO { get; set; }
    }
}
