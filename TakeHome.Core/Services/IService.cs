using System.Collections.Generic;
using System.Threading.Tasks;
using TakeHome.Core.Entities;

namespace TakeHome.Core.Services
{

    public interface IService<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        void AddAsync(T entity);

    }
}
