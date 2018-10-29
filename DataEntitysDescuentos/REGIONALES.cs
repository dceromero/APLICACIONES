namespace DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;
    public partial class REGIONALES
    {
        public REGIONALES()
        {
            VENDEDORES = new HashSet<VENDEDORES>();
        }
        
        public string ID_REGIONAL { get; set; }
        
        public string NAMEREGIONAL { get; set; }
        
        public virtual ICollection<VENDEDORES> VENDEDORES { get; set; }
    }
}
