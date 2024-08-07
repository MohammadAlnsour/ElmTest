using ElmTest.Domain.Entities;

namespace ElmTest.Infrastructure.Dapper
{
    public interface IBookDbService
    {
        Task<IEnumerable<Book>> GetBooksPagedAsync(int pageNumber, int pageSize);
    }
}
