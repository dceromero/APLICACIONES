using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosCupoCredito
    {
        private ModelAplicacionesDescuentos dbcontext;

        public Mensajes InsertarCredito(SOLICITUDESCUPO sol)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"exec InsertarCupoCredito '{sol.TIPOSOL}', '{sol.CODCLIENTE}', '{sol.CEDULA}', '{sol.CUPOSOLICITADO}', '{sol.VIGENCIA}'";
            var result = dbcontext.Database.SqlQuery<Mensajes>(tsql).FirstOrDefault();
            return result;
        }
    }
}
