using DAL.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstractions.Repositories
{
    public interface IRepository<T> where T : class, IModel
    {
        Task<int?> CreateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<T> GetAsync(int id);

        Task<IEnumerable<T>> GetAllAsync(Page page);

        Task UpdateAsync(T entity);
    }
}
