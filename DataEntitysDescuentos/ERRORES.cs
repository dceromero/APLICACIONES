namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class ERRORES
    {
        [Key]
        public long IDERROR { get; set; }

        public DateTime FECHA { get; set; }

        [Required]
        public string PRODUJOERROR { get; set; }

        public short LINEADELERROR { get; set; }

        [Required]
        public string MENSAJE { get; set; }
    }
}
