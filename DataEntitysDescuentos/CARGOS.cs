namespace DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;

    public partial class CARGOS
    {
        public CARGOS()
        {
            USUARIOS = new HashSet<USUARIOS>();
        }
        
        public string ID_CARGO { get; set; }
        
        public string NAMECARGO { get; set; }
        
        public virtual ICollection<USUARIOS> USUARIOS { get; set; }
    }
}
