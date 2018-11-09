namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class JEFATURAS
    {
        [Key]
        public int IDJEFATURA { get; set; }

        public long? CODJEFATURA { get; set; }

        public long? CODEMPLEADO { get; set; }

        public virtual USUARIOS USUARIOS { get; set; }

        public virtual USUARIOS USUARIOS1 { get; set; }
    }
}
