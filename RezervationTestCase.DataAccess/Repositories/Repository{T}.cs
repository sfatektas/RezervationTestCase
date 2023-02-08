using Microsoft.EntityFrameworkCore;
using RezervationTestCase.Common.Enums;
using RezervationTestCase.DataAccess.Context;
using RezervationTestCase.DataAccess.Interfaces;
using RezervationTestCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        readonly TestCaseDbContext _context;

        public Repository(TestCaseDbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> keySelector, OrderByType OrderByType = OrderByType.DESC)
        {
            var list = (OrderByType == OrderByType.DESC) ? await _context.Set<T>().AsNoTracking().OrderByDescending(keySelector).Where(filter).ToListAsync() :
                await _context.Set<T>().AsNoTracking().OrderBy(keySelector).Where(filter).ToListAsync();
            return list;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public T Update(T entity) // unchanged kullanmak daha doğru !!!!
        {
            //return await _context.Set
            _context.Update(entity);
            return entity;
        }
        public async Task<List<T>> GetByFilterAsync(Expression<Func<T,bool>> filter)
        {
            return await _context.Set<T>().Where(filter).ToListAsync();
        }
        public IQueryable<T> GetQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}
