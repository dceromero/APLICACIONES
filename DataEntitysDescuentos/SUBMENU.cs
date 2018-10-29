namespace DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;
    
    public partial class SUBMENU
    {
        public SUBMENU()
        {
            PERMISOS = new HashSet<PERMISOS>();
        }

        public short ID_SUBMENU { get; set; }

        public short? ID_MENU { get; set; }

        public string NAMESUBMENU { get; set; }
        
        public string URLSUBMENU { get; set; }
        
        public string ICOSUBMENU { get; set; }

        public virtual MENU MENU { get; set; }
        
        public virtual ICollection<PERMISOS> PERMISOS { get; set; }
    }
}
