using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLab5.Models
{
  //  token: string,
  //type: string,
  //payload: any
    public class AppMessage
    {
        public string Token { get; set; }
        public string Type { get; set; }
        public object Payload { get; set; }
    }
}
