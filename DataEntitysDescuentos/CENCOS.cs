namespace DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;

    public partial class CENCOS
    {
        public CENCOS()
        {
            USUARIOS = new HashSet<USUARIOS>();
        }
        
        public long ID_CENCOS { get; set; }

        public string NAMECENCOS { get; set; }
        
        public virtual ICollection<USUARIOS> USUARIOS { get; set; }
    }
}
