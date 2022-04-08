using Microsoft.EntityFrameworkCore;
using MovimaxNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovimaxNet.Repositories.EFCore
{
    internal abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected DatabaseContext context;
        internal DbSet<T> db;

        public RepositoryBase(DatabaseContext context)
        {
            this.context = context;
            this.db = context.Set<T>();
        }

        public virtual async Task<bool> Add(T data)
        {
            await db.AddAsync(data);
            return true;
        }

        public virtual Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> Get(int id)
        {
            return await db.FindAsync(id);
        }

        public virtual Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Update(T data)
        {
            throw new NotImplementedException();
        }
    }
}
