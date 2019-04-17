using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class MDDCTOCANAL
    {
        [Key]
        public long ID_MDDCTOCANAL { get; set; }

        public long ID_MCDCTOCANAL { get; set; }

        public string CODPRODUCTO { get; set; }

        public byte PORCENDCTO { get; set; }

        public byte VERIFICA1 { get; set; }

        public byte VERIFICA2 { get; set; }

        public byte VERIFICA3 { get; set; }

        public byte APRUEBA1 { get; set; }

        public byte APRUEBA2 { get; set; }

        public string OBS { get; set; }

        public int CANT { get; set; }

        public float VALOR { get; set; }

        public byte APRUEBA3 { get; set; }

        public byte APRUEBA4 { get; set; }

        public byte APRUEBA5 { get; set; }

        public virtual  MCDCTOCANAL MCDCTOCANAL { get; set; }

    }
}
