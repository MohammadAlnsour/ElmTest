using AutoMapper;
using ElmTest.Application.Contracts.ApiResponse;
using ElmTest.Application.Requests;
using ElmTest.Domain.Entities;
using ElmTest.Domain.Factories;
using ElmTest.Infrastructure.Repositories;
using FluentValidation;
using MediatR;

namespace ElmTest.Application.Commands
{
    public class CreateBookCommandRequestHandler : IRequestHandler<CreateBookRequest, long>
    {
        private readonly IBookFactory _bookFactory;
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandRequestHandler(IBookFactory bookFactory, IMapper mapper, IBookRepository bookRepository)
        {
            _bookFactory = bookFactory;
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        public async Task<long> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            var bookInfo = _mapper.Map<CreateBookRequest, BookInfo>(request);
            var book = _bookFactory.CreateBook(bookInfo.BookTitle, bookInfo.BookDescription, bookInfo.Author, bookInfo.PublishDate, bookInfo.CoverBase64);

            try
            {
                return await _bookRepository.Insert(book);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
