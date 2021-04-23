using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstractions.Models
{
    public class Media : IModel
    {
        public int MediaId { get; set; }
        public string ImageUrl { get; set; }

        [NotMapped]
        public int KeyId => MediaId;
    }
}
