using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Validators.ErrorMessages;
using FluentValidation;

namespace com.Github.Haseoo.BMMS.Business.Validators
{
    public class OrderListEditDtoValidator : AbstractValidator<OrderListUpdateDto>
    {
        public OrderListEditDtoValidator(OrderListPositionEditDtoValidator orderListPositionEditDtoValidator)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(ErrorMessageGenerator
                    .GetEmptyValidationErrorMessage(ValidatedEntities.OrderList));
            RuleForEach(x => x.OrderPositions)
                .SetValidator(orderListPositionEditDtoValidator)
                .When(x => x.OrderPositions != null);
        }
    }
}