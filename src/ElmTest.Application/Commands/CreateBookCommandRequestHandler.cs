using AutoMapper;
using ElmTest.Application.Requests;
using ElmTest.Domain.Entities;
using ElmTest.Domain.Factories;
using ElmTest.Infrastructure.Repositories;
using MediatR;
using Serilog;
using StackExchange.Redis;
using ElmTest.Shared.AppExceptions;

namespace ElmTest.Application.Commands
{
    public class CreateBookCommandRequestHandler : IRequestHandler<CreateBookRequest, long>
    {
        private readonly IBookFactory _bookFactory;
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IDatabase _redisDb;
        private readonly ILogger _logger;

        public CreateBookCommandRequestHandler(
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
        public async Task<long> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {

            var bookInfo = _mapper.Map<CreateBookRequest, BookInfo>(request);
            var book = _bookFactory.CreateBook(bookInfo.BookTitle, bookInfo.BookDescription, bookInfo.Author, bookInfo.PublishDate, bookInfo.CoverBase64);

            try
            {
                return await _bookRepository.Insert(book);
            }
            catch (Exception ex)
            {
                ex.HandleException(_logger);
                throw;
            }
        }
    }
}
