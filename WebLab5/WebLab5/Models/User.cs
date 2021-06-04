using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebLab5.Models
{
    public class User
    {
        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("telegramLogin")]
        public string TelegramLogin { get; set; }

        [JsonIgnore]
        public string ConnectionId { get; set; }
    }
}
