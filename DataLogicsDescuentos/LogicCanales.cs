using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicCanales
    {
        MetodosCanales mtcanales = null;

        public List<CANALES> ListadoCanales()
        {
            mtcanales = new MetodosCanales();
            return mtcanales.ListadoCanales();
        }

        public async Task<string> GuadarSolicitudDescuento(MCDCTOCANAL mc)
        {
            mtcanales = new MetodosCanales();
            Mensajes msg = new Mensajes();
            string mensaje = string.Empty;
            long i = mtcanales.SaveMCDsctoCanal(mc);
            if (i >= 0)
            {
                foreach (var md in mc.MDDCTOCANAL)
                {
                    md.ID_MCDCTOCANAL = i;
                    msg = mtcanales.SaveMDDsctoCanal(md,  mc.CEDULA);
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

        public async Task<string> ActualizarMD(List<MDDCTOCANAL> mc, long cc)
        {
             mtcanales = new MetodosCanales();
            Mensajes msj = new Mensajes();
            string update = "";
            foreach (var md in mc)
            {
                msj = mtcanales.UpdateMDDescuentos(md, cc);
                update = msj.message;
            }
            if (msj.id == 1)
            {
                MetodosEnviarEmail mtsend = new MetodosEnviarEmail();
                update = await mtsend.EnviarMensaje(msj.message);
            }
            return update;
        }
        
        public List<VIEW_HEADER_CANAL> ListadoXAutorizar(long cc)
        {
            mtcanales = new MetodosCanales();
            return mtcanales.CabeceraCanal(cc);
        }

        public VIEW_HEADER_CANAL Cabecera(long id)
        {
            mtcanales = new MetodosCanales();
            var cn = mtcanales.CabeceraCN(id);
            cn.VIEW_VALORPORCANAL = mtcanales.ValorProductXCanal(id);
            return cn;
        }

        public List<VIEW_ENCABEZADO_INFORME_CANAL> EncabezadoInforme()
        {
            mtcanales = new MetodosCanales();
            return mtcanales.EncabezadoInformes();
        }

        public List<VIEW_CANAl_EXCEL_SAP> ExportarExcel(long id)
        {
            mtcanales = new MetodosCanales();
            return mtcanales.ExportarExcel(id);
        }

    }
}
