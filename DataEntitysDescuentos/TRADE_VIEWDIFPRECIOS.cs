using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitysAplicaciones.DataEntitysDescuentos
{
    public class TRADE_VIEWDIFPRECIOS
    {
        public long ID_LEGALIZA { get; set; }
        public long ID_MCNOTACOMERCIAL { get; set; }
        public DateTime FEC_INGRESO { get; set; }
        public DateTime FEC_LEGALIZA { get; set; }
        public long CEDULA { get; set; }
        public string SOLICITANTE { get; set; }
        public string RESPONSABLE { get; set; }
        public string CLIENTE { get; set; }
        public string CONCEPTO { get; set; }
        public double VALSOL { get; set; }
        public double VALLEG { get; set; }
        public bool PROVISION { get; set; }
        public int NRO_PROV { get; set; }
        public int NRO_REVPROV { get; set; }
        public int NRO_SAP { get; set; }
        public byte APROBGERREG { get; set; }
        public byte APROBCOORDTRADE { get; set; }
        public byte APROBGERCOM { get; set; }
        public byte APROBJFTRADE { get; set; }
        public virtual List<TRADE_MDLEGALIZACION> listMDLegalizacion { get; set; }
        public virtual List<TRADE_DOCUMENTOS> listDocument { get; set; }
    }
}
