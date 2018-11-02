using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosCencos
    {

        ModelAplicacionesDescuentos dbcontext = null;

        public List<CENCOS> ListadoDeCentroCostos()
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.CENCOS.SqlQuery("select ID_CENCOS, CONCAT(ID_CENCOS,' - ',NAMECENCOS)as namecencos from CENCOS").ToList();
        }

    }
}
