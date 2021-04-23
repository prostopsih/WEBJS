using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstractions.DTO
{
    public class TourLowInfo
    {
        public int TourId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
