using ElmTest.Domain.Entities;
using ElmTest.Infrastructure.Dapper;

namespace ElmTest.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IBookDbService _bookDbService;

        public BookRepository(IBookDbService bookDbService)
        {
            _bookDbService = bookDbService;
        }

        public Task<bool> Delete(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task<Book> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetPaged(int pageNumber, int pageSize)
        {
            return await _bookDbService.GetBooksPagedAsync(pageNumber, pageSize);
        }

        public Task<long> Insert(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
