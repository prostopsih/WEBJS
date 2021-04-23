using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Abstractions.Models;

namespace DAL.Abstractions.Repositories
{
    public interface IMediaRepository : IRepository<Media>
    {
        Task<bool> Contains(string path);
    }
}
