namespace DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;

    public partial class CANALES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CANALES()
        {
            VENDEDORES = new HashSet<VENDEDORES>();
        }
        
        public short ID_CANAL { get; set; }

    
        public string NAMECANALES { get; set; }

        public virtual ICollection<VENDEDORES> VENDEDORES { get; set; }
    }
}
