using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Abstractions.Models
{
    public class Tour : IModel
    {
        public int TourId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }
        public int MaxTouristsCount { get; set; }
        public DateTime StartDate { get; set; }

        public virtual IEnumerable<Ticket> Tickets { get; set; }
        [NotMapped]
        public int KeyId => TourId;
    }
}
