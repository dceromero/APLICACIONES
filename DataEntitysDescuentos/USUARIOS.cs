namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class USUARIOS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CEDULA { get; set; }

        public long CODIGO { get; set; }

        [Required]
        [StringLength(30)]
        public string NOMBRES { get; set; }

        [Required]
        [StringLength(30)]
        public string APELLIDOS { get; set; }

        [Required]
        public string CLAVE { get; set; }

        public long JEFEAREA { get; set; }

        [Required]
        [StringLength(50)]
        public string MAIL { get; set; }

        public long TELEFONO { get; set; }

        public short NIVELUSUARIO { get; set; }

        public short ID_ROL { get; set; }

        public long NIT_EMPRESA { get; set; }

        public long ID_CENCOS { get; set; }

        [Required]
        [StringLength(10)]
        public string ID_CARGO { get; set; }

        [Required]
        [StringLength(5)]
        public string COD_VENDEDOR { get; set; }

        public bool ESTADO { get; set; }

        public virtual CARGOS CARGOS { get; set; }

        public virtual CENCOS CENCOS { get; set; }

        public virtual EMPRESAS EMPRESAS { get; set; }

        public virtual ROLES ROLES { get; set; }

        public virtual VENDEDORES VENDEDORES { get; set; }
    }
}
