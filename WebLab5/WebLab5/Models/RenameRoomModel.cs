using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebLab5.Models
{
    public class RenameRoomModel
    {
        [JsonPropertyName("oldRoomName")]
        public string OldRoomName { get; set; }

        [JsonPropertyName("newRoomName")]
        public string NewRoomName { get; set; }
    }
}
