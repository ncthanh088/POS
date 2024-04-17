using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace POS.Infrastructure.DAL.Repositories
{
    public static class Extensions
    {
        public static IQueryable<TEntity> Include<TEntity>(this DbSet<TEntity> dbSet,
                                            params Expression<Func<TEntity, object>>[] includes)
                                            where TEntity : class
        {
            IQueryable<TEntity> query = null;
            foreach (var include in includes)
            {
                query = dbSet.Include(include);
            }

            return query ?? dbSet;
        }
    }
}
