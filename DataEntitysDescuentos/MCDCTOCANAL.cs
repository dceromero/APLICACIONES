using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class MCDCTOCANAL
    {
        public MCDCTOCANAL()
        {
            MDDCTOCANAL = new HashSet<MDDCTOCANAL>();
        }

        [Key]
        public long ID_MCDCTOCANAL { get; set; }

        public long CEDULA { get; set; }

        public string ID_OFICVENTA { get; set; }

        public short ID_CANAL { get; set; }

        public string GRPCLIENTE { get; set; }

        public DateTime FECING { get; set; }

        public DateTime FECINI { get; set; }

        public DateTime FECFIN { get; set; }

        public long IDMOTIVOS { get; set; }

        public string JUSTIFICACION { get; set; }

        public virtual ICollection<MDDCTOCANAL> MDDCTOCANAL { get; set; }

    }
}
