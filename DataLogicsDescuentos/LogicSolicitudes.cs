using System;
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


    }
}
