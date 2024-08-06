using ElmTest.Application.Contracts.ApiResponse;
using ElmTest.Application.Contracts.DTOs;
using ElmTest.Application.Requests;
using ElmTest.Domain.Consts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ElmTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : BaseController
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetBookPagination")]
        public async Task<ApiResponse<IEnumerable<BookReponseDTO>>> Get(int? pageNumber, int? pageSize)
        {
            try
            {
                var response = await _mediator.Send(new GetBooksPaginationRequest() { PageNumber = pageNumber ?? 1, PageSize = pageSize ?? 10 });
                return ApiResponse<IEnumerable<BookReponseDTO>>.IsSuccess(response, "Request succeed", ApiStatusCodes.Success.ToString());
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<BookReponseDTO>>.IsFailed($"error occued {ex.Message}", ApiStatusCodes.Error.ToString());
            }
        }

        [HttpPost("PostBook")]
        public async Task<ApiResponse<long>> PostBook(CreateBookRequest createBookRequest)
        {
            try
            {
                var response = await _mediator.Send(createBookRequest);
                return ApiResponse<long>.IsSuccess(response, $"Book created Id {response}", ApiStatusCodes.Success.ToString());
            }
            catch (Exception ex)
            {
                return ApiResponse<long>.IsFailed($"error occued {ex.Message}", ApiStatusCodes.Error.ToString());
            }
        }

    }
}

