using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstractions.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public int Role { get; set; }
        public DateTime RegisteredAt { get; set; }
        public string AvaUrl { get; set; }

        public IEnumerable<TicketLowInfo> Tickets { get; set; }
    }
}
