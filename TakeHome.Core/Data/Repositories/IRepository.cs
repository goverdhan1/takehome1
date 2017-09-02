using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeHome.Core.Entities;

namespace TakeHome.Core.Data.Repositories
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
