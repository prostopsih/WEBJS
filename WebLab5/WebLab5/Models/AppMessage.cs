using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebLab5.Models
{
  //  token: string,
  //type: string,
  //payload: any
    public class AppMessage
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("payload")]
        public object Payload { get; set; }
    }
}
