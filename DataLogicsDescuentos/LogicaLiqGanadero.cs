using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicaLiqGanadero
    {
        MetodosPDFs pdf = null;

        public string PdfLiqganadero(LiqGanaderos liq)
        {
            pdf =new MetodosPDFs();
            MetodosLiqGanaderos mtLiq = new MetodosLiqGanaderos();
            return pdf.pdfGanadero(mtLiq.listaGanaderos(liq));
        }

        public string getPDFLiq(LiqGanaderos liq)
        {
            pdf = new MetodosPDFs();
            MetodosLiqGanaderos mtLiq = new MetodosLiqGanaderos();
            return pdf.pdfGanadero(mtLiq.Ganaderos(liq));
        }

        public List<string> listAcopio()
        {
            MetodosLiqGanaderos mtLiq = new MetodosLiqGanaderos();
            return mtLiq.getListAcopio();
        }

        public List<DateTime> listDateLiq()
        {
            MetodosLiqGanaderos mtLiq = new MetodosLiqGanaderos();
            return mtLiq.getListDateLiq();
        }
    }
}
