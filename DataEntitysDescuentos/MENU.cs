namespace DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;

    public partial class MENU
    {
        public MENU()
        {
            SUBMENU = new HashSet<SUBMENU>();
        }
        
        public short ID_MENU { get; set; }

       
        public string NAMEMENU { get; set; }
        
        public string ICOMENU { get; set; }
        
        public virtual ICollection<SUBMENU> SUBMENU { get; set; }
    }
}
