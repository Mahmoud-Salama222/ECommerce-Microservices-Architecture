using Microsoft.EntityFrameworkCore;
using Ordering.Core.Common;
using Ordering.Core.IRpositries;
using Ordering.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.AsyncRepositry
{
    public class RepositryBase<T> : IAsyncRepository<T> where T : BaseEntity
    {
        private readonly OrderContext context;

        public RepositryBase(OrderContext context)
        {
            this.context = context;
        }
        public async Task<T> AddAsync(T Entity)
        {
            await context.AddAsync(Entity);
            await context.SaveChangesAsync();
            return Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await context.Set<T>().FindAsync(Id);
        }


        public async Task UpadteAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
