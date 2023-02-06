using RezervationTestCase.DataAccess.Context;
using RezervationTestCase.DataAccess.Repositories;
using RezervationTestCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.DataAccess.Interfaces
{
    public interface IUow
    {
        public Repository<T> GetRepository<T>() where T : BaseEntity;

        public Task SaveChangesAsync();
    }
}
