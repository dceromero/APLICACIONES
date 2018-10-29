namespace DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;

    public partial class VENDEDORES
    {
        public VENDEDORES()
        {
            USUARIOS = new HashSet<USUARIOS>();
        }
        
        public string COD_VENDEDOR { get; set; }

      
        public string NAMEVENDEDOR { get; set; }
        
        public string ID_REGIONAL { get; set; }

        public string ID_OFICVENTA { get; set; }

        public short ID_CANAL { get; set; }

        public bool ESTADO { get; set; }

        public virtual CANALES CANALES { get; set; }

        public virtual OFICVENTAS OFICVENTAS { get; set; }

        public virtual REGIONALES REGIONALES { get; set; }
        
        public virtual ICollection<USUARIOS> USUARIOS { get; set; }
    }
}
