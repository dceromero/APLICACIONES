using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosEmpresas
    {
        ModelAplicacionesDescuentos dbcontext = null;

        public List<EMPRESAS> LitadoDeEmpresas()
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.EMPRESAS.SqlQuery("Select * from Empresas order by NAMEEMPRESA").ToList();
        }

    }
}
