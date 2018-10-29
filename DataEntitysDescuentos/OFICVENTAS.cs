namespace DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;

    public partial class OFICVENTAS
    {
        public OFICVENTAS()
        {
            VENDEDORES = new HashSet<VENDEDORES>();
        }
        
        public string ID_OFICVENTA { get; set; }
        
        public string NAMEOFICVENTA { get; set; }
        
        public virtual ICollection<VENDEDORES> VENDEDORES { get; set; }
    }
}
