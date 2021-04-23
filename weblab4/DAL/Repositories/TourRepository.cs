using DAL.Abstractions.Models;
using DAL.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TourRepository : GenericRepository<Tour>, ITourRepository
    {
        public TourRepository(DbContext context) : base(context)
        {

        }

        protected override async Task AddReferencesAsync(Tour model)
        {
            await _context.Entry(model).Collection(x => x.Tickets).LoadAsync();
        }
    }
}
