using AutoMapper;
using ElmTest.Application.Contracts.ApiResponse;
using ElmTest.Application.Requests;
using ElmTest.Domain.Entities;
using ElmTest.Domain.Factories;
using FluentValidation;
using MediatR;

namespace ElmTest.Application.Commands
{
    public class CreateBookCommandRequestHandler : IRequestHandler<CreateBookRequest, long>
    {
        private readonly IBookFactory _bookFactory;
        private readonly IMapper _mapper;

        public CreateBookCommandRequestHandler(IBookFactory bookFactory, IMapper mapper)
        {
            _bookFactory = bookFactory;
            _mapper = mapper;
        }
        public Task<long> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            var bookInfo = _mapper.Map<CreateBookRequest, BookInfo>(request);
            var book = _bookFactory.CreateBook(bookInfo.BookTitle, bookInfo.BookDescription, bookInfo.Author, bookInfo.PublishDate, bookInfo.CoverBase64);

            return Task.FromResult(long.MinValue);
        }
    }
}
