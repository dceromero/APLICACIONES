namespace DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;
    public partial class ROLES
    {
        public ROLES()
        {
            PERMISOS = new HashSet<PERMISOS>();
            USUARIOS = new HashSet<USUARIOS>();
        }
        
        public short ID_ROL { get; set; }
        
        public string NAMEROL { get; set; }
        
        public virtual ICollection<PERMISOS> PERMISOS { get; set; }
        
        public virtual ICollection<USUARIOS> USUARIOS { get; set; }
    }
}
