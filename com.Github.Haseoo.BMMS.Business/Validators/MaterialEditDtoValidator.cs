using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Validators.ErrorMessages;
using FluentValidation;

namespace com.Github.Haseoo.BMMS.Business.Validators
{
    public class MaterialEditDtoValidator : AbstractValidator<MaterialOperationDto>
    {
        public MaterialEditDtoValidator()
        {
            RuleFor(x => x.Name).
                NotEmpty()
                .When(x => x.Name != null)
                .WithMessage(ErrorMessageGenerator
                    .GetEmptyValidationErrorMessage(ValidatedEntities.Material));
        }
    }
}