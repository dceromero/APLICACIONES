using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;
using DataAccessAplicaciones.DataAccessDescuentos;
namespace ServicioDescuentos
{
    public class MetodosDescuentos
    {
        private string nodo = "ET_RETURN";
        private string url = "/sap/bc/srt/rfc/sap/ysdds_co_crea_cond_zd11/010/ysdds_co_crea_cond_zd11_prd/ysdds_co_crea_cond_zd11_binding";
        
        private string body(REPAADMONTRADE data)
        {
            var canal = data.CODCANAL == 5 ? "05" : data.CODCANAL.ToString();
            return "<urn:YSDRFC_CREA_COND_ZD11>" +
       "<ET_RETURN>" +
      "<!--Zero or more repetitions:-->" +
       " <item>" +
      " <TYPE></TYPE>" +
       "<ID></ID>" +
      " <NUMBER></NUMBER>" +
       "<MESSAGE></MESSAGE>" +
       "<LOG_NO></LOG_NO>" +
       "<LOG_MSG_NO></LOG_MSG_NO>" +
       "<MESSAGE_V1></MESSAGE_V1>" +
       "<MESSAGE_V2></MESSAGE_V2>" +
       "<MESSAGE_V3></MESSAGE_V3>" +
       "<MESSAGE_V4></MESSAGE_V4>" +
       "<PARAMETER></PARAMETER>" +
       "<ROW></ROW>" +
       "<FIELD></FIELD>" +
       "<SYSTEM></SYSTEM>" +
      "</item>" +
       "</ET_RETURN>" +
       "<IP_KAPPL>V</IP_KAPPL>" +
       "<IP_KSCHL>ZD11</IP_KSCHL>" +
       "<IP_PRO>1</IP_PRO>" +
       "<!--Optional:-->" +
       "<IT_A305>" +
       " <!--Zero or more repetitions:-->" +
      "<item>" +
       "<MANDT>010</MANDT>" +
      " <KAPPL>V</KAPPL>" +
      " <KSCHL>ZD11</KSCHL>" +
      " <VKORG>CO10</VKORG>" +
      $" <VTWEG>{canal}</VTWEG>" +
       $"<KUNNR>{data.CODCLIENTE}</KUNNR>" +
       $"<MATNR>{data.CODPRODUCTO}</MATNR>" +
       $"<KBETR>{data.PORCENDESC.ToString().Replace(',','.')}</KBETR>" +
      $"<DATAB>{data.FECINI.Replace('.','-')}</DATAB>" +
       $"<DATBI>{data.FECFIN.Replace('.', '-')}</DATBI>" +
       " </item>" +
       "</IT_A305>" +
       "<!--Optional:-->" +
       "<IT_A947>" +
      "<!--Zero or more repetitions:-->" +
       " <item>" +
      " <MANDT></MANDT>" +
       "<KAPPL></KAPPL>" +
      " <KSCHL></KSCHL>" +
      " <VKORG></VKORG>" +
       "<VTWEG></VTWEG>" +
       "<VKBUR></VKBUR>" +
       "<KDGRP></KDGRP>" +
       "<MATNR></MATNR>" +
       "<KBETR></KBETR>" +
       "<DATAB></DATAB>" +
       "<DATBI></DATBI>" +
      "</item>" +
       "</IT_A947> " +
      "</urn:YSDRFC_CREA_COND_ZD11>";

        }


        public IEnumerable<DatosDescuentos> Guardar(string codcliente = "N")
        {
            MetodosSolicitud mtsol = new MetodosSolicitud();
            foreach (var rp in mtsol.RepDetalleSolicitudTrade())
            {
                DataServices ds = new DataServices();
                var result = ds.SendDescuento(body(rp), url, nodo);
                mtsol.UpdateDetalle(rp.ID_MDDESCUENTO, result);
            }
            return null;
        }
    }
}
