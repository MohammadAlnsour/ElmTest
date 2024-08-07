using ElmTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmTest.Infrastructure.Repositories
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<Book>> GetPaged(int pageNumber, int pageSize);
        Task<T> Get(int id);
        Task<long> Insert(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
