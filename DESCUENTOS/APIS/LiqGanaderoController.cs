using DataEntitysAplicaciones.DataEntitysDescuentos;
using DataLogicAplicaciones.DataLogicsDescuentos;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace DESCUENTOS.APIS
{
    public class LiqGanaderoController : ApiController
    {
        LogicaLiqGanadero lgLiqGanadero = null;

        [HttpPost]
        public string Ganadero(LiqGanaderos liq)
        {
            lgLiqGanadero = new LogicaLiqGanadero();
            return lgLiqGanadero.PdfLiqganadero(liq);
        }

        [HttpPost]
        public string getGanadero(LiqGanaderos liq)
        {
            lgLiqGanadero = new LogicaLiqGanadero();
            return lgLiqGanadero.getPDFLiq(liq);
        }

        [HttpGet]
        public List<string> ApiListAcopi()
        {
            lgLiqGanadero = new LogicaLiqGanadero();
            return lgLiqGanadero.listAcopio();
        }

        [HttpGet]
        public List<DateTime> ApiListDateLiq()
        {
            lgLiqGanadero = new LogicaLiqGanadero();
            return lgLiqGanadero.listDateLiq();
        }
    }
}
