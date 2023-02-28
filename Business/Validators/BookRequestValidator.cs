using Business.RequestModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators
{
    public class BookRequestValidator : AbstractValidator<BookRequestModel>
    {
        public BookRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} must not be empty.")
                .GreaterThan(0).WithMessage("Wrong Id");

            RuleFor(x => x.Title)
                .NotNull()
                .Length(2, 25)
                .NotEmpty().WithMessage("{PropertyName} must not be empty.");

            RuleFor(x => x.Cover)
                .Must(IsBase64String).WithMessage("Wrong image type");

            RuleFor(x => x.Content)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} must not be empty.");

            RuleFor(x => x.Genre)
                .NotNull()
                .Length(2, 25)
                .NotEmpty().WithMessage("{PropertyName} must not be empty.");

            RuleFor(x => x.Author)
                .NotNull()
                .Length(2, 25)
                .NotEmpty().WithMessage("{PropertyName} must not be empty.");
        }

        private static bool IsBase64String(string base64)
        {
            Span<byte> buffer = new(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, buffer, out int bytesParsed);
        }
    }
}
