using DAL.Abstractions.Models;
using DAL.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(DbContext context) : base(context)
        {
        }

        protected override async Task AddReferencesAsync(Ticket model)
        {
            await _context.Entry(model).Reference(x => x.User).LoadAsync();
            await _context.Entry(model).Reference(x => x.Tour).LoadAsync();
        }
    }
}
