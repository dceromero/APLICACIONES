namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CLIENTES_SECTOR
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CODCLIENTE { get; set; }

        [Required]
        [StringLength(4)]
        public string CODORGANIZACION { get; set; }

        public short ID_CANAL { get; set; }

        [Required]
        [StringLength(2)]
        public string CODSECTOR { get; set; }

        [Required]
        [StringLength(4)]
        public string CODOFICINA { get; set; }

        [Required]
        [StringLength(5)]
        public string COD_VENDEDOR { get; set; }

        [Required]
        [StringLength(6)]
        public string ZONAVENTAS { get; set; }

        [Required]
        [StringLength(2)]
        public string GRUPOCLI { get; set; }

        public bool ESTADO { get; set; }

        public virtual CANALES CANALES { get; set; }

        public virtual VENDEDORES VENDEDORES { get; set; }
    }
}
