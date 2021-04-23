using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Abstractions.Models
{
    public class User : IModel
    {
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        public string FullName { get; set; }
        public int Role { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.Now;
        [Url]
        public string AvaUrl { get; set; }
        public bool Enabled { get; set; } = true;

        public virtual IEnumerable<Ticket> Tickets { get; set; }
        [NotMapped]
        public int KeyId => UserId;
    }
}
