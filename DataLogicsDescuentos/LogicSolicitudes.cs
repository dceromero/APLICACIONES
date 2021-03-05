﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicSolicitudes
    {
        
        public List<TIPOSOLICITUD> ListarTiposSolicitudes()
        {
            MetodosTipoSolicitud mttpSolictudes = new MetodosTipoSolicitud();
            return mttpSolictudes.TpSolicitudes();
        }

        public async Task<string> GuadarSolicitudDescuento(MCDESCUENTOS mc)
        {
            MetodosSolicitud mtsol = new MetodosSolicitud();
            Mensajes msg = new Mensajes();
            string mensaje = string.Empty;
            long i = mtsol.SaveMCDescuento(mc);
            if (i >= 0)
            {
                foreach(var md in mc.MDDESCUENTO)
                {
                    md.ID_MCDESCUENTO = i;
                    msg=  mtsol.SaveMDDescuento(md, mc.ID_SOLICITD, mc.CEDULA);
                    if (msg.id == 0)
                    {
                        break;
                    }
                }
                if (msg.id != 0)
                {
                    MetodosEnviarEmail mtsend = new MetodosEnviarEmail();
                    if (msg.id == 2)
                    {
                        mensaje = await mtsend.EnviarMensajeRech(msg.message);
                    }
                    else
                    {
                        mensaje = await mtsend.EnviarMensaje(msg.message);
                    }
                }

            }
            return mensaje;
        }
        public List<VIEW_ENCABEZADO> ListadoEncabezados(long cedula)
        {
            MetodosSolicitud mtsol = new MetodosSolicitud();
            return mtsol.ListadoEncabezado(cedula);
        }
        public VIEW_ENCABEZADO Encabezados(long idmc)
        {
            MetodosSolicitud mtsol = new MetodosSolicitud();
            var enc = mtsol.Encabezado(idmc);
            enc.VIEW_VALORPORCLIENTE = mtsol.ProductosClientes(idmc);
            return enc;
        }

        public async Task<string> ActualizarMD(List<MDDESCUENTO> mc, long cc)
        {
            MetodosSolicitud mtsol = new MetodosSolicitud();
            Mensajes msj = new Mensajes();
            string update = "";
            foreach(var md in mc)
            {
                msj = mtsol.UpdateMDDescuentos(md, cc);
                update = msj.message;
            }
            if (msj.id == 1)
            {
                MetodosEnviarEmail mtsend = new MetodosEnviarEmail();
                update = await mtsend.EnviarMensaje(msj.message);
            }
            return update;
        }


        public string ActualizarMasivo(List<MDDESCUENTO> mc, long cc)
        {
            MetodosSolicitud mtsol = new MetodosSolicitud();
            Mensajes msj = new Mensajes();
            string update = "";
            foreach (var md in mc)
            {
                msj = mtsol.UpdateMDDescuentos(md, cc);
                update = "Registros Aprobados";
            }
            mtsol.EjecutarPrograma();
            return update;
        }

            public List<VIEW_ENCABEZADO_INFORME> EncabezadoInforme()
        {
            MetodosSolicitud mtsol = new MetodosSolicitud();
            return mtsol.EncabezadoInformes();
        }

        public List<VIEW_EXCEL_SAP> ExportarExcel(long idmc)
        {
            MetodosSolicitud mtsol = new MetodosSolicitud();
            return mtsol.ExportarExcel(idmc);
        }

        public List<VIEW_EXCEL_SAP> ExportarExcel(MCDESCUENTOS fechas)
        {
            MetodosSolicitud mtsol = new MetodosSolicitud();
            return mtsol.ExportarExcel(fechas);
        }

        public void ActualizarDonwLoad(long id, short tpdcto)
        {
            MetodosSolicitud mtsol = new MetodosSolicitud();
            mtsol.ActualizarDescarga(id, tpdcto);
        }


        public List<APROBACIONTRADE> listaTrade()
        {
            MetodosSolicitud  mtsol = new MetodosSolicitud();
            return mtsol.listAprobacionTrade();
        }

        public List<VIEW_VENDEDORES> listaDescuentos(MCDESCUENTOS mc)
        {
            MetodosSolicitud mtsol = new MetodosSolicitud();
            return mtsol.listadoVendedores(mc);
        }

        public List<REPAADMONVENTAS> DetalleDescuentos(MCDESCUENTOS mc)
        {
            MetodosSolicitud mtsol = new MetodosSolicitud();
            return mtsol.RepDetalleSolicitudVendedor(mc);
        }

        public List<REPAADMONVENTAS> DetalleConsolidado(MCDESCUENTOS mc)
        {
            MetodosSolicitud mtsol = new MetodosSolicitud();
            return mtsol.RepDetalleSolicitud(mc);
        }
    }
}
