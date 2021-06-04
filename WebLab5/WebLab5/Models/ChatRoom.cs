using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebLab5.Models
{
    //    {
    //  name: string,
    //  owner: string
    //}

    public class ChatRoom
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("owner")]
        public string Owner { get; set; }

        [JsonIgnore]
        public List<string> Members { get; } = new List<string>();
        public List<ChatMessage> Messages { get; } = new List<ChatMessage>();
    }
}
