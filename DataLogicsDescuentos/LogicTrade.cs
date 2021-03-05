using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicTrade
    {
        private MetodosTrade mttrade = null;

        public List<TIPOSOLICITUD> listTipoSolicitud(short id)
        {
            mttrade = new MetodosTrade();
            return mttrade.listTipoSolicitud(id);
        }

        public List<TIPODENOTA> listNotas()
        {
            mttrade = new MetodosTrade();
            return mttrade.listNotas();
        }

        public List<TRADE_VIEWCONCEPTO> listConceptos(long codcliente)
        {
            mttrade = new MetodosTrade();
            return mttrade.listConceptos(codcliente);
        }

        public string saveNotas(TRADE_MCNOTAXPRECIO nota)
        {
            mttrade = new MetodosTrade();
            MetodosEnviarEmail send = new MetodosEnviarEmail();
            var JF = mttrade.saveMCNotaXPrecio(nota);
            foreach (var md in nota.listMDNotasXPrecios)
            {
                md.ID_MCNOTAXPRECIO = JF.ID;
                mttrade.saveMDNotaxPrecio(md);
            }
            return send.EnviarMensajeNotasComerciales(JF.JEFE);
        }

        public List<TRADE_VIEWNOTA> listNotasEstado(long cedula)
        {
            mttrade = new MetodosTrade();
            return mttrade.listNotasEstados(cedula);
        }

        public List<TRADE_VIEWNOTA> listActivacion(long cedula)
        {
            mttrade = new MetodosTrade();
            var notaativacion = new List<TRADE_VIEWNOTA>();
            foreach (var nota in mttrade.listNotasEstadosActivacion(cedula))
            {
                nota.datosLegalizacion = mttrade.notaLegalizacion(nota.ID_MCNOTACOMERCIAL);
                nota.listDetail = mttrade.listDetailAprobacion(nota.ID_MCNOTACOMERCIAL);
                if (nota.datosLegalizacion != null)
                {
                    nota.datosLegalizacion.detailLegalizacion = mttrade.detailLegalizacion(nota.datosLegalizacion.ID_LEGALIZA);

                }
                notaativacion.Add(nota);
            }
            return notaativacion;
        }

        public List<TRADE_VIEWDIFPRECIOS> listLegalizacion(long cedula)
        {
            mttrade = new MetodosTrade();
            return mttrade.listNotasLegalizada(cedula);
        }

        public List<TRADE_VIEWNOTA> listNotas(long cedula)
        {
            mttrade = new MetodosTrade();
            return mttrade.listNotasComerciales(cedula);
        }

        public TRADE_VIEWNOTA notaAprobacion(long idmc)
        {
            mttrade = new MetodosTrade();
            var nota = mttrade.NotasAprobacion(idmc);
            nota.listDetail = mttrade.listDetailAprobacion(idmc);
            nota.datosLegalizacion = mttrade.notaLegalizacion(idmc);
            if (nota.datosLegalizacion != null)
            {
                nota.datosLegalizacion.detailLegalizacion = mttrade.detailLegalizacion(nota.datosLegalizacion.ID_LEGALIZA);
                nota.datosLegalizacion.documentosLegal = mttrade.legalizacionDocumentos(nota.datosLegalizacion.ID_LEGALIZA);
            }
            return nota;
        }

        public MensajeAI AprobacionTrade(TRADE_MCNOTAXPRECIO nota)
        {
            mttrade = new MetodosTrade();
            MetodosEnviarEmail send = new MetodosEnviarEmail();
            var mensaje = mttrade.aprobarNotasComerciales(nota);
            var correo = send.EnviarMensajeNotasComerciales(mensaje.JEFE);
            mensaje.JEFE = correo;
            return mensaje;
        }

        public List<PLANILLANOTACOMERCIAL> planilla()
        {
            mttrade = new MetodosTrade();
            return mttrade.planilla();
        }

        public List<PLANILLANOTACOMERCIAL> planillaProv()
        {
            mttrade = new MetodosTrade();
            MetodosLegalizacion mtlg = new MetodosLegalizacion();
            if (DateTime.Now.Day >= 28 && DateTime.Now.Day <= 31  )
            {
                mtlg.updateProvision();
                return mttrade.planillaProv();
            }
            return null;
        }

        public List<PLANILLANOTACOMERCIAL> planillaRProv()
        {
            mttrade = new MetodosTrade();
            return mttrade.planillaRProv();
        }

        public void ActualizarPlanilla()
        {
            mttrade = new MetodosTrade();
            mttrade.updatePlanilla();
        }

        public void guardarDetalle(TRADE_MDNOTAXPRECIO md)
        {
            mttrade = new MetodosTrade();
            mttrade.saveMDNotaxPrecio(md);
        }
        public void eliminar(long id)
        {
            mttrade = new MetodosTrade();
            mttrade.Eliminar(id);
        }

        public MensajeAI AprobacionAdmonVelas(TRADE_MCNOTAXPRECIO nota)
        {
            mttrade = new MetodosTrade();
            MetodosEnviarEmail send = new MetodosEnviarEmail();
            var mensaje = mttrade.updateAdmonSales(nota);
            var correo = send.EnviarMensajeNotasComerciales(mensaje.JEFE);
            mensaje.JEFE = correo;
            return mensaje;
        }

        public List<TRADE_VIEWNOTA> listAdmonVentas()
        {
            mttrade = new MetodosTrade();
            return mttrade.listAdmonSales();
        }

        public List<TRADE_VIEWDIFPRECIOS> listAdmonComercial()
        {
            mttrade = new MetodosTrade();
            return mttrade.listAdmonComercial();
        }

        public List<TRADE_VIEWDIFPRECIOS> listAdmonComercial(TRADE_MCNOTAXPRECIO fecha)
        {
            mttrade = new MetodosTrade();
            return mttrade.listAdmonComercial(fecha);
        }

        public List<TRADE_INFORMEREVENEW> informeRevenew(TRADE_MCNOTAXPRECIO nota)
        {
            mttrade = new MetodosTrade();
            return mttrade.informeNotas(nota);
        }


        public MensajeAI AprobacionLegal(TRADE_MCNOTAXPRECIO nota)
        {
            mttrade = new MetodosTrade();
            MetodosEnviarEmail send = new MetodosEnviarEmail();
            var mensaje = mttrade.AprobLegalizacion(nota);
            var correo = send.EnviarMensajeNotasComerciales(mensaje.JEFE);
            mensaje.JEFE = correo;
            return mensaje;
        }

        public List<TRADE_VIEWDIFPRECIOS> ListAprobacionLegal(long cedula)
        {
            mttrade = new MetodosTrade();
            var listaprob =mttrade.ListAprobLegalizacion(cedula);
            foreach(var lista in listaprob)
            {
                lista.listDocument = mttrade.legalizacionDocumentos(lista.ID_LEGALIZA);
            }
            return listaprob;
        }

        public TRADE_VIEWDIFPRECIOS viewAprobLegalizacion(long id)
        {
            mttrade = new MetodosTrade();
            var legal = mttrade.tradeLegalizacion(id);
            if (legal != null)
            {
                legal.listMDLegalizacion = mttrade.listTradeLegalizacion(id);
            }
            return legal;
        }

        public List<TRADE_VIEWINFORMESOLICITUD> informeSolicitudes(long cedula,TRADE_VIEWINFORMESOLICITUD vm)
        {
            mttrade = new MetodosTrade();
            return mttrade.informSolicitud(cedula,vm);
        }

    }
}
