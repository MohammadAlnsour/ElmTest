using AutoMapper;
using ElmTest.Application.Contracts.DTOs;
using ElmTest.Application.Requests;
using ElmTest.Domain.Entities;
using ElmTest.Domain.Factories;
using ElmTest.Infrastructure.Repositories;
using MediatR;

namespace ElmTest.Application.Queries
{
    public class GetBooksQueryPaginationRequestHandler : IRequestHandler<GetBooksPaginationRequest, IEnumerable<BookReponseDTO>>
    {
        private readonly IBookFactory _bookFactory;
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public GetBooksQueryPaginationRequestHandler(IBookFactory bookFactory, IMapper mapper, IBookRepository bookRepository)
        {
            _bookFactory = bookFactory;
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<BookReponseDTO>> Handle(GetBooksPaginationRequest request, CancellationToken cancellationToken)
        {
            var dbBooks = await _bookRepository.GetPaged(request.PageNumber, request.PageSize);
            var booksDTOs = _mapper.Map<IEnumerable<BookReponseDTO>>(dbBooks);
            return booksDTOs;
        }
    }
}
