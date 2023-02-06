using RezervationTestCase.DataAccess.Context;
using RezervationTestCase.DataAccess.Interfaces;
using RezervationTestCase.DataAccess.Repositories;
using RezervationTestCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        readonly TestCaseDbContext _context;

        public Uow(TestCaseDbContext context)
        {
            _context = context;
        }

        public Repository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
