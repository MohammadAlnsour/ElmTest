using ElmTest.Application.Contracts.DTOs;
using MediatR;

namespace ElmTest.Application.Requests
{
    public class GetBooksPaginationRequest : IRequest<IEnumerable<BookReponseDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
