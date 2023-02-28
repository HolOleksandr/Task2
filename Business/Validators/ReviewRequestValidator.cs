using Business.RequestModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators
{
    public class ReviewRequestValidator : AbstractValidator<ReviewRequestModel>
    {
        public ReviewRequestValidator()
        {
            RuleFor(x => x.Reviewer)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} should be not empty.")
                .Length(2, 25)
                .Must(IsValidName).WithMessage("{PropertyName} should be all letters.");

            RuleFor(x => x.Message)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} should be not empty.")
                .Length(2, 124);
        }

        private static bool IsValidName(string name)
        {
            return name.All(Char.IsLetter);
        }
    }
}
