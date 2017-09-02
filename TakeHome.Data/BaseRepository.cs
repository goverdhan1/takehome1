using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeHome.Core.Data.Repositories;
using TakeHome.Core.Entities;

namespace TakeHome.Data
{
    public class BaseRepository<T> :IRepository<T> where T: BaseEntity
    {
        private readonly IDbContext _context;
        private readonly IDbSet<T> _dbEntitySet;
        private bool _disposed;

        public BaseRepository(IDbContext context)
        {
            _context = context;
            _dbEntitySet = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbEntitySet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbEntitySet.FirstOrDefaultAsync(t => t.Id == id);
        }

        public void Add(T entity)
        {
            _context.SetAsAdded(entity);
        }

        public void Update(T entity)
        {
            _context.SetAsModified(entity);
        }

        public void Delete(T entity)
        {
            _context.SetAsDeleted(entity);
        }

        
    }
}
