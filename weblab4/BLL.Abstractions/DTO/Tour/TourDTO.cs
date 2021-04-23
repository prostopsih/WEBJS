using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstractions.DTO
{
    public class TourDTO
    {
        public int TourId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }
        public int MaxTouristsCount { get; set; }
        public DateTime StartDate { get; set; }

        public IEnumerable<TicketLowInfo> Tickets { get; set; }
    }
}
