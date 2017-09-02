using System;
using System.Collections.Generic;
using System.Linq;
using TakeHome.Core.Data.Repositories;
using TakeHome.Core.Entities;

namespace TakeHome.Data.Repositories
{
    public class EmployeeCaseRepository : BaseRepository<EmployeeCase>, IEmployeeCaseRepository
    {
        private readonly IDbContext _context;
        public EmployeeCaseRepository(IDbContext context) : base (context)
        {
            _context = context;
        }

        public List<EmployeeCase> GetCasesByEmployee(int id)
        {
           return _context.Set<EmployeeCase>().Where(x => x.EmployeeId == id).ToList();
        }
    }
}
