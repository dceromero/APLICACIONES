using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DataEntitysAplicaciones.DataEntitysDescuentos;
using DataLogicAplicaciones.DataLogicsDescuentos;
using Newtonsoft.Json;
namespace DESCUENTOS.APIS
{
    public class SolicitudesController : ApiController
    {
        LogicSolicitudes lgsolict = null;

        [HttpPost]
        public string ListarTiposSolicitudes()
        {
            lgsolict = new LogicSolicitudes();
            return JsonConvert.SerializeObject(lgsolict.ListarTiposSolicitudes());
        }


        [HttpPost]
        public string ListarEncabezados()
        {
            lgsolict = new LogicSolicitudes();
            return JsonConvert.SerializeObject(lgsolict.ListadoEncabezados());
        }

        [HttpPost]
        public string Encabezados(long id)
        {
            lgsolict = new LogicSolicitudes();
            return JsonConvert.SerializeObject(lgsolict.Encabezados(id));
        }

        [HttpPost]
        public async Task<string> Guadarsolicitud(MCDESCUENTOS headerDescuentos)
        {
            lgsolict = new LogicSolicitudes();
            var result = await lgsolict.GuadarSolicitudDescuento(headerDescuentos);
            return JsonConvert.SerializeObject(result);
        }
    }
}
