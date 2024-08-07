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
        IEnumerable<T> GetAll();
        IEnumerable<T> GetPaged(int pageNumber, int pageSize);
        IEnumerable<T> Get(int id);
        long Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
