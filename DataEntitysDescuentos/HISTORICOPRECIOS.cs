namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HISTORICOPRECIOS
    {
        [Key]
        public long IDHISPRECIO { get; set; }

        public int ID_PRECIO { get; set; }

        public double VALOR { get; set; }

        public DateTime FECINI { get; set; }

        public DateTime? FECFIN { get; set; }

        public virtual PRECIOS PRECIOS { get; set; }
    }
}
