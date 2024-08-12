using AutoMapper;
using ElmTest.Application.Contracts.DTOs;
using ElmTest.Application.Requests;
using ElmTest.Domain.Entities;
using ElmTest.Domain.Factories;
using ElmTest.Infrastructure.Repositories;
using ElmTest.Shared.AppExceptions;
using MediatR;
using Newtonsoft.Json;
using Serilog;
using StackExchange.Redis;

namespace ElmTest.Application.Queries
{
    public class GetBooksQueryPaginationRequestHandler : IRequestHandler<GetBooksPaginationRequest, IEnumerable<BookReponseDTO>>
    {
        private readonly IBookFactory _bookFactory;
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IDatabase _redisDb;
        private readonly ILogger _logger;

        public GetBooksQueryPaginationRequestHandler(
            IBookFactory bookFactory,
            IMapper mapper,
            IBookRepository bookRepository,
            IDatabase redisDb,
            ILogger logger)
        {
            _bookFactory = bookFactory;
            _mapper = mapper;
            _bookRepository = bookRepository;
            _redisDb = redisDb;
            _logger = logger;
        }
        public async Task<IEnumerable<BookReponseDTO>> Handle(GetBooksPaginationRequest request, CancellationToken cancellationToken)
        {
            var booksPagedJson = await _redisDb.StringGetAsync($"Book_{request.PageNumber}");
            if (!booksPagedJson.IsNullOrEmpty)
            {
                var booksDTOsRedis = JsonConvert.DeserializeObject<IEnumerable<BookReponseDTO>>(booksPagedJson);
                return booksDTOsRedis;
            }
            else
            {
                try
                {
                    var dbBooks = await _bookRepository.GetPaged(request.PageNumber, request.PageSize);
                    var booksDTOs = MapBooks(dbBooks);
                    await _redisDb.StringSetAsync($"Book_{request.PageNumber}", JsonConvert.SerializeObject(booksDTOs));
                    return booksDTOs;
                }
                catch (Exception ex)
                {
                    ex.HandleException(_logger);
                    throw;
                }
            }
        }
        private IEnumerable<BookReponseDTO> MapBooks(IEnumerable<Book> books)
        {
            return books.Select(b =>
            {
                var bookDto = new BookReponseDTO();
                try
                {
                    var bookInfo = JsonConvert.DeserializeObject<BookInfo>(b.BookInfo);
                    bookDto = new BookReponseDTO()
                    {
                        Author = bookInfo?.Author,
                        BookDescription = bookInfo?.BookDescription,
                        BookId = b.BookId,
                        BookTitle = bookInfo?.BookTitle,
                        CoverBase64 = bookInfo?.CoverBase64,
                        LastModifiedDate = b.LastModified,
                        PublishDate = bookInfo.PublishDate
                    };
                    return bookDto;
                }
                catch (Exception ex)
                {
                    ex.HandleException(_logger);
                    throw;
                }
            }
            );
        }
    }
}
