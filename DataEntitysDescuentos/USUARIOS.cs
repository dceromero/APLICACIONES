namespace DataEntitysDescuentos
{
    using System;
    using System.Collections.Generic;

    public partial class USUARIOS
    {
        public long CEDULA { get; set; }

        public long CODIGO { get; set; }
        
        public string NOMBRES { get; set; }
        
        public string APELLIDOS { get; set; }
        
        public byte[] CLAVE { get; set; }

        public long JEFEAREA { get; set; }
        
        public string MAIL { get; set; }

        public long TELEFONO { get; set; }

        public short NIVELUSUARIO { get; set; }

        public short ID_ROL { get; set; }

        public long NIT_EMPRESA { get; set; }

        public long ID_CENCOS { get; set; }
        
        public string ID_CARGO { get; set; }
        
        public string COD_VENDEDOR { get; set; }

        public bool ESTADO { get; set; }

        public virtual CARGOS CARGOS { get; set; }

        public virtual CENCOS CENCOS { get; set; }

        public virtual EMPRESAS EMPRESAS { get; set; }

        public virtual ROLES ROLES { get; set; }

        public virtual VENDEDORES VENDEDORES { get; set; }
    }
}
