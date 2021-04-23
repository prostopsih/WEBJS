using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstractions.DTO
{
    public class TicketDTO
    {
        public int TicketId { get; set; }
        public string Header { get; set; }

        public TourLowInfo Tour { get; set; }
        public UserLowInfo User { get; set; }
    }
}
