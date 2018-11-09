namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
