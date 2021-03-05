using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace ServicioDescuentos
{
    public class ClientesSector
    {
        public ClienteSector Clientesector { get; set; }
    }

    public class ClienteSector
    {
        public List<TEMP_CLIENTESECTOR> item { get; set; }
    }
}
