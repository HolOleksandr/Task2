using Business.RequestModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators
{

    public class RatingRequestValidator : AbstractValidator<RatingRequestModel>
    {
        public RatingRequestValidator()
        {
            RuleFor(x => x.Score)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} should be not empty.")
                .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} musts be more than 1.")
                .LessThanOrEqualTo(5).WithMessage("{PropertyName} musts be less than 5.");
                
        }
    }
}