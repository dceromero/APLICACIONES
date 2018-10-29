namespace DataEntitysDescuentos
{
    using System;

    public partial class ERRORES
    {
        public long IDERROR { get; set; }

        public DateTime FECHA { get; set; }

        public string PRODUJOERROR { get; set; }

        public short LINEADELERROR { get; set; }
        
        public string MENSAJE { get; set; }
    }
}
