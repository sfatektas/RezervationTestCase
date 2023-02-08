using RezervationTestCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task<T> GetByIdAsync(int id);

        public Task<List<T>> GetAllAsync();

        public Task<List<T>> GetAllAsync(Expression<Func<T,bool>> filter);

        Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> filter);

        IQueryable<T> GetQueryable();

        public Task<T> CreateAsync (T entity);

        public T Update(T entity);
    }
}
