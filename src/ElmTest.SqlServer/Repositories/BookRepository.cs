using ElmTest.Domain.Entities;

namespace ElmTest.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        public bool Delete(Book entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetPaged(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();

        }

        public long Insert(Book entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
