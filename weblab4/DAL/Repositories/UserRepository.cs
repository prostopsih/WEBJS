using DAL.Abstractions.Models;
using DAL.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        protected override async Task AddReferencesAsync(User model)
        {
            await _context.Entry(model).Collection(x => x.Tickets).LoadAsync();
        }
    }
}
