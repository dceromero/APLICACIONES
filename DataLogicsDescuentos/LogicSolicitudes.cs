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
                    msg=  mtsol.SaveMDDescuento(md, mc.ID_SOLICITD);
                    if (msg.id == 0)
                    {
                        break;
                    }
                }
                if (msg.id != 0)
                {
                    MetodosEnviarEmail mtsend =new  MetodosEnviarEmail();
                    mensaje= await mtsend.EnviarMensaje(msg.message);
                }

            }
            return mensaje;
        }

        public List<VIEW_ENCABEZADO> ListadoEncabezados()
        {
            MetodosSolicitud mtsol = new MetodosSolicitud();
            return mtsol.ListadoEncabezado();
        }

        public VIEW_ENCABEZADO Encabezados(long idmc)
        {
            MetodosSolicitud mtsol = new MetodosSolicitud();
            var enc = mtsol.Encabezado(idmc);
            enc.VIEW_VALORPORCLIENTE = mtsol.ProductosClientes(idmc);
            return enc;
        }

    }
}
