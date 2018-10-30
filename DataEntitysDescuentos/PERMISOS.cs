namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System.ComponentModel.DataAnnotations;

    public partial class PERMISOS
    {
        [Key]
        public short ID_PERMISO { get; set; }

        public short ID_ROL { get; set; }

        public short ID_SUBMENU { get; set; }

        public virtual ROLES ROLES { get; set; }

        public virtual SUBMENU SUBMENU { get; set; }
    }
}
