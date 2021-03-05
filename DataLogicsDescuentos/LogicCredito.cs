using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicCredito
    {
        private MetodosCupoCredito credito;
        private MetodosEnviarEmail mail; 

        public async Task<string> GuardarAsync(SOLICITUDESCUPO sol)
        {
            string result = "";
            try
            {
                credito = new MetodosCupoCredito();
               Mensajes msg= credito.InsertarCredito(sol);
                result = await mail.EnviarMensajeCredito(msg.message);
            }catch(Exception ex)
            {
                result = ex.Message.ToString();
            }
            return result;
        }
    }
}
