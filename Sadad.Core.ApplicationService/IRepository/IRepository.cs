using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadad.Core.ApplicationService.IRepository
{
   public interface IRepository<T>
    {
        void Insert(T item);
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        T Update(T item);
        Task Delete(int id);
        IQueryable<T> GetQuery();
        Task Save();
    }
}
