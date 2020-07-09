using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Validators.ErrorMessages;
using FluentValidation;

namespace com.Github.Haseoo.BMMS.Business.Validators
{
    public class MaterialAddDtoValidator : AbstractValidator<MaterialOperationDto>
    {
        public MaterialAddDtoValidator()
        {
            RuleFor(x => x.Name).
                NotEmpty()
                .WithMessage(ErrorMessageGenerator
                    .GetEmptyValidationErrorMessage(ValidatedEntities.Material));
        }
    }
}