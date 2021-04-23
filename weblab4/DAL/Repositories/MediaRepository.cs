using DAL.Abstractions.Repositories;
using DAL.Abstractions.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MediaRepository : GenericRepository<Media>, IMediaRepository
    {
        public MediaRepository(DbContext context) : base(context)
        {
        }

        protected override Task AddReferencesAsync(Media model)
        {
            return Task.FromResult(0);
        }

        public async Task<bool> Contains(string path)
        {
            return await _table.Where(x => x.ImageUrl == path).AnyAsync();
        }
    }
}
