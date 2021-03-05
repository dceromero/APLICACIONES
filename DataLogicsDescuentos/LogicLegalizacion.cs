using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicLegalizacion
    {
        private MetodosLegalizacion mtLegalizacion = null;
        
        public void guardarMDLegalizacion(TRADE_MDLEGALIZACION md)
        {
            mtLegalizacion = new MetodosLegalizacion();
             mtLegalizacion.guardarMDLegalizacion(md);
        }

        public string saveDocumento(TRADE_DOCUMENTOS td)
        {
            mtLegalizacion = new MetodosLegalizacion();
            mtLegalizacion.legalizar(td);
            return "Enviado";
        }

        public void eliminarMDLegalizacion(long idmd)
        {
            mtLegalizacion = new MetodosLegalizacion();
            mtLegalizacion.eliminarMDLegalizacion(idmd);
        }

        public void actualizarNProv(long id, int nprov)
        {
            mtLegalizacion = new MetodosLegalizacion();
            mtLegalizacion.actualizarNprov(id,nprov);
        }
        public void actualizarRProv(long id, int rprov)
        {
            mtLegalizacion = new MetodosLegalizacion();
            mtLegalizacion.actualizarRprov(id, rprov);
        }
        public void actualizarNSap(long id, int nsap)
        {
            mtLegalizacion = new MetodosLegalizacion();
            mtLegalizacion.actualizarNSAP(id, nsap);
        }

        public List<PLANILLANOTACOMERCIAL> plantillaLegalzacion()
        {
            mtLegalizacion = new MetodosLegalizacion();
            return mtLegalizacion.plantillaLegalizacion();
        }

        public void actualizarPlanilla()
        {
            mtLegalizacion = new MetodosLegalizacion();
            mtLegalizacion.updatePlanilla();
        }

        public void actualizarPlanProv()
        {
            mtLegalizacion = new MetodosLegalizacion();
            mtLegalizacion.updatePlanillaProv();
        }

        public void actualizarPlanRProv()
        {
            mtLegalizacion = new MetodosLegalizacion();
            mtLegalizacion.updatePlanillaRProv();
        }

        public List<TRADE_MDLEGALIZACION> detailLegalizacion(long id)
        {
            mtLegalizacion = new MetodosLegalizacion();
          return  mtLegalizacion.detailLegalizacion(id);
        }
    }
}
