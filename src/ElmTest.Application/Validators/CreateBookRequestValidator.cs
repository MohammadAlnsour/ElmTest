using ElmTest.Application.Requests;
using ElmTest.Domain.Consts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmTest.Application.Validators
{
    public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
    {
        public CreateBookRequestValidator()
        {
            RuleFor(x => x.BookTitle)
                .NotNull()
                .WithErrorCode(ApiErrorCodes.BookTitleRequired.Key)
                .WithMessage(ApiErrorCodes.BookTitleRequired.Value);

            RuleFor(x => x.BookTitle)
                .Length(1, 200)
                .WithErrorCode(ApiErrorCodes.BookTitleLengthNotCorrect.Key)
                .WithMessage(ApiErrorCodes.BookTitleLengthNotCorrect.Value);

            RuleFor(x => x.Author).Length(1, 50);
            RuleFor(x => x.PublishDate).NotNull();
            RuleFor(x => x.BookDescription).NotNull();
        }
    }
}
