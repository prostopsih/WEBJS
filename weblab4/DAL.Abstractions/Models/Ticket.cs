using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Abstractions.Models
{
    public class Ticket : IModel
    {
        public int TicketId { get; set; }
        public string Header { get; set; }

        public int UserId { get; set; }
        public int TourId { get; set; }

        public virtual Tour Tour { get; set; }
        public virtual User User { get; set; }
        [NotMapped]
        public int KeyId => TicketId;
    }
}
