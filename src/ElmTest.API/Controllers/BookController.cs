using ElmTest.Application.Contracts.ApiResponse;
using ElmTest.Application.Contracts.DTOs;
using ElmTest.Application.Requests;
using ElmTest.Domain.Consts;
using ElmTest.Shared.AppExceptions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ElmTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateBookRequest> _validator;
        private readonly Serilog.ILogger _logger;

        public BookController(IMediator mediator, IValidator<CreateBookRequest> validator, Serilog.ILogger logger)
        {
            _mediator = mediator;
            _validator = validator;
            _logger = logger;
        }

        [HttpGet(Name = "GetBookPagination")]
        [EnableCors("AllowAll")]
        public async Task<ApiResponse<IEnumerable<BookReponseDTO>>> Get(int? pageNumber, int? pageSize)
        {
            try
            {
                if (pageNumber != null && pageNumber == 0) pageNumber = 1;
                var getBooksRequest = new GetBooksPaginationRequest(pageNumber ?? 1, pageSize ?? 10);
                var response = await _mediator.Send(getBooksRequest);
                return ApiResponse<IEnumerable<BookReponseDTO>>.IsSuccess(response, "Request succeed", ApiStatusCodes.Success.ToString());
            }
            catch (Exception ex)
            {
                ex.HandleException(_logger);
                return ApiResponse<IEnumerable<BookReponseDTO>>.IsFailed($"error occued {ex.Message}", ApiStatusCodes.Error.ToString());
            }
        }

        [HttpPost("PostBook")]
        [EnableCors("AllowAll")]
        public async Task<ApiResponse<long>> PostBook(CreateBookRequest createBookRequest)
        {
            try
            {
                var validationResult = _validator.Validate(createBookRequest);
                if (!validationResult.IsValid)
                {
                    var validationErrors = new List<ValidationError>();
                    validationErrors = validationResult.Errors.Select(e => new ValidationError() { Code = e.ErrorCode, Message = e.ErrorMessage }).ToList();
                    return ApiResponse<long>.IsFailed("validation error", "203", validationErrors);
                }

                var response = await _mediator.Send(createBookRequest);
                return ApiResponse<long>.IsSuccess(response, $"Book created Id {response}", ApiStatusCodes.Success.ToString());
            }
            catch (Exception ex)
            {
                ex.HandleException(_logger);
                return ApiResponse<long>.IsFailed($"error occued {ex.Message}", ApiStatusCodes.Error.ToString());
            }
        }

    }
}

