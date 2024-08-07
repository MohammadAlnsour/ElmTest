using ElmTest.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;
using System.Data.SqlClient;

namespace ElmTest.Infrastructure.Dapper
{
    public class BookDbService : IBookDbService
    {
        private readonly IConfiguration _configuration;
        public BookDbService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<Book>> GetBooksPagedAsync(int pageNumber, int pageSize)
        {
            var connectionString = _configuration.GetConnectionString("ReadConnection");

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    var books = await connection.QueryAsync<Book>("GetBooksPagination",
                        new { PageNumber = pageNumber, PageSize = pageSize },
                        commandType: CommandType.StoredProcedure);

                    return books;
                }
            }
            catch (Exception )
            {

                throw;
            }

        }
    }
}
