namespace com.Github.Haseoo.BMMS.Business.Validators
{
    public class ValidatorContext
    {
        public ValidatorContext()
        {
            CompanyContactDataValidator = new CompanyContactDataValidator();
            CompanyOperationDtoValidator = new CompanyOperationDtoValidator(CompanyContactDataValidator);
            MaterialAddDtoValidator = new MaterialAddDtoValidator();
            MaterialEditDtoValidator = new MaterialEditDtoValidator();
            OfferAddDtoValidator = new OfferAddDtoValidator();
            OfferEditDtoValidator = new OfferEditDtoValidator();
            OrderListPositionAddDtoValidator = new OrderListPositionAddDtoValidator();
            OrderListPositionEditDtoValidator = new OrderListPositionEditDtoValidator();
            OrderListEditDtoValidator = new OrderListEditDtoValidator(OrderListPositionEditDtoValidator);
        }

        public CompanyContactDataValidator CompanyContactDataValidator { get; }
        public MaterialAddDtoValidator MaterialAddDtoValidator { get; }
        public MaterialEditDtoValidator MaterialEditDtoValidator { get; }
        public CompanyOperationDtoValidator CompanyOperationDtoValidator { get; }
        public OfferAddDtoValidator OfferAddDtoValidator { get; }
        public OfferEditDtoValidator OfferEditDtoValidator { get; }
        public OrderListEditDtoValidator OrderListEditDtoValidator { get; }
        public OrderListPositionAddDtoValidator OrderListPositionAddDtoValidator { get; }
        public OrderListPositionEditDtoValidator OrderListPositionEditDtoValidator { get; }
    }
}