using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioDescuentos
{

    public class DatosDescuentos
    {
        [JsonProperty("ET_RETURN")]
        public EtReturn EtReturn { get; set; }
    }
    public class EtReturn
    {
        [JsonProperty("item")]
        public Item Item { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("TYPE")]
        public string Type { get; set; }

        [JsonProperty("ID")]
        public object Id { get; set; }

        [JsonProperty("NUMBER")]
        public string Number { get; set; }

        [JsonProperty("MESSAGE")]
        public string Message { get; set; }

        [JsonProperty("LOG_NO")]
        public object LogNo { get; set; }

        [JsonProperty("LOG_MSG_NO")]
        public string LogMsgNo { get; set; }

        [JsonProperty("MESSAGE_V1")]
        public object MessageV1 { get; set; }

        [JsonProperty("MESSAGE_V2")]
        public object MessageV2 { get; set; }

        [JsonProperty("MESSAGE_V3")]
        public object MessageV3 { get; set; }

        [JsonProperty("MESSAGE_V4")]
        public object MessageV4 { get; set; }

        [JsonProperty("PARAMETER")]
        public object Parameter { get; set; }

        [JsonProperty("ROW")]
        public long Row { get; set; }

        [JsonProperty("FIELD")]
        public object Field { get; set; }

        [JsonProperty("SYSTEM")]
        public object System { get; set; }
    }
}
