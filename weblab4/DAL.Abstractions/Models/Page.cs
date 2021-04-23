using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstractions.Models
{
    public class Page
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int ToSkip => (PageNumber - 1) * PageSize;
        public int ToTake => PageSize;
    }
}
