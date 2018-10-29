namespace DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;

    public partial class EMPRESAS
    {
        public EMPRESAS()
        {
            USUARIOS = new HashSet<USUARIOS>();
        }
        
        public long NIT_EMPRESA { get; set; }
        
        public string NAMEEMPRESA { get; set; }
        
        public virtual ICollection<USUARIOS> USUARIOS { get; set; }
    }
}
