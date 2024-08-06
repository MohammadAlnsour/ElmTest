using ElmTest.Application.Contracts.DTOs;
using ElmTest.Application.Requests;
using MediatR;

namespace ElmTest.Application.Queries
{
    public class GetBooksQueryPaginationRequestHandler : IRequestHandler<GetBooksPaginationRequest, IEnumerable<BookReponseDTO>>
    {
        public GetBooksQueryPaginationRequestHandler()
        {
            
        }
        public Task<IEnumerable<BookReponseDTO>> Handle(GetBooksPaginationRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
