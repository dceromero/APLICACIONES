namespace DataEntitysDescuentos
{
    using System;

    public partial class PERMISOS
    {
        public short ID_PERMISO { get; set; }

        public short ID_ROL { get; set; }

        public short ID_SUBMENU { get; set; }

        public virtual ROLES ROLES { get; set; }

        public virtual SUBMENU SUBMENU { get; set; }
    }
}
