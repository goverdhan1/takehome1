using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeHome.Core.Data.Repositories;
using TakeHome.Core.Entities;
using TakeHome.Core.Services;
using TakeHome.Data;

namespace TakeHome.Services
{
    public abstract class BaseService<T> : IService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;
        private bool _disposed;
        public IUnitOfWork _unitOfWork { get; private set; }

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<T>();
        }
        public Task<List<T>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<T> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public void AddAsync(T entity)
        {
            _repository.Add(entity);
        }

    }
}
