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
    public abstract class GenericRepository<T> : IRepository<T> where T : class, IModel
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _table;

        protected virtual IQueryable<T> GetBaseIncludes()
        {
            return _table;
        }

        public GenericRepository(DbContext context)
        {
            this._context = context;
            this._table = context.Set<T>();
        }
        public virtual async Task<int?> CreateAsync(T entity)
        {
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity?.KeyId;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            var model = await _table.FindAsync(id);

            if (model == null) return null;

            await AddReferencesAsync(model);
            return model;
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync(Page page)
        {
            var models = await _table.Skip(page.ToSkip).Take(page.ToTake).ToListAsync();
            foreach(var model in models)
            {
                await AddReferencesAsync(model);
            }
            return models;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _table.Update(entity);
            await _context.SaveChangesAsync();
        }

        protected abstract Task AddReferencesAsync(T model);

    }
}
