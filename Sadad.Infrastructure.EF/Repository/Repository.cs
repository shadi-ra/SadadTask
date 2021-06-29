using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sadad.Core.ApplicationService.IRepository;
using Sadad.Core.Entities;
using Sadad.Infrastructure.EF.DataBase;

namespace Sadad.Infrastructure.EF.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IHasIdentity
    {
        private readonly SadadDbContext dbContext;

        public Repository(SadadDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Delete(int id)
        {
            var item = await this.dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            this.dbContext.Remove(item);
        }

        public async Task<T> Get(int id)
        {
            return await this.dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<T>> GetAll()
        {
            return await this.dbContext.Set<T>().ToListAsync();
        }

        public void Insert(T item)
        {

            this.dbContext.Add(item);
        }

        public async Task Save()
        {
            await this.dbContext.SaveChangesAsync();
        }

        public T Update(T item)
        {
            this.dbContext.Update(item);
            return item;
        }

        public IQueryable<T> GetQuery()
        {
            return dbContext.Set<T>().AsQueryable();
        }
    }
}
