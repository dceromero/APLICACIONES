using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosLiqGanaderos
    {

        ModelAplicacionesDescuentos dbcontext = null;


        public List<LiqGanaderos> listaGanaderos(LiqGanaderos liq)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from v_liq_ganadero where ACOPIO = '{liq.ACOPIO}' and FEC_LIQ = '{liq.FEC_LIQ.ToString("yyyy-MM-dd")}'";
            return dbcontext.Database.SqlQuery<LiqGanaderos>(tsql).ToList();
        }

        public List<LiqGanaderos> Ganaderos(LiqGanaderos liq)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"select * from v_liq_ganadero where ACOPIO = '{liq.ACOPIO}' and FEC_LIQ = '{liq.FEC_LIQ.ToString("yyyy-MM-dd")}' and NIT_CED = '{liq.NIT_CED}'";
            return dbcontext.Database.SqlQuery<LiqGanaderos>(tsql).ToList();
        }

        public List<DateTime> getListDateLiq()
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = "select distinct FEC_LIQ from v_liq_ganadero";
            return dbcontext.Database.SqlQuery<DateTime>(tsql).ToList();
        }

        public List<string> getListAcopio()
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = "select distinct ACOPIO from v_liq_ganadero";
            return dbcontext.Database.SqlQuery<string>(tsql).ToList();
        }
    }
}
