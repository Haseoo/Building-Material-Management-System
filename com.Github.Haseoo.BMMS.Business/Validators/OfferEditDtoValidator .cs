using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Validators.ErrorMessages;
using FluentValidation;

namespace com.Github.Haseoo.BMMS.Business.Validators
{
    public class OfferEditDtoValidator : AbstractValidator<OfferOperationDto>
    {
        public OfferEditDtoValidator()
        {
            RuleFor(x => x.Unit)
                .NotEmpty()
                .When(x => x.Unit != null)
                .WithMessage(ErrorMessageGenerator
                    .GetEmptyValidationErrorMessage(ValidatedEntities.Offer));
            RuleFor(x => x.UnitPrice)
                .GreaterThan(0M)
                .WithMessage("Price must be greater than zero");
        }
    }
}