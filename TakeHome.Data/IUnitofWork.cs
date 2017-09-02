using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeHome.Core.Data.Repositories;
using TakeHome.Core.Entities;

namespace TakeHome.Data
{
    public interface IUnitOfWork 
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

        void BeginTransaction();

        int Commit();

        Task<int> CommitAsync();

        void Rollback();

        

    }
}
