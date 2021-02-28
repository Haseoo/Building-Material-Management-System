namespace com.Github.Haseoo.BMMS.Business.Validators
{
    public class ValidatorContext
    {
        public ValidatorContext()
        {
            CompanyContactDataValidator = new CompanyContactDataValidator();
            CompanyAddDtoValidator = new CompanyAddDtoValidator(CompanyContactDataValidator);
            MaterialAddDtoValidator = new MaterialAddDtoValidator();
            CompanyEditDtoValidator = new CompanyEditDtoValidator(CompanyContactDataValidator);
            MaterialEditDtoValidator = new MaterialEditDtoValidator();
            OfferAddDtoValidator = new OfferAddDtoValidator();
            OfferEditDtoValidator = new OfferEditDtoValidator();
        }

        public CompanyContactDataValidator CompanyContactDataValidator { get; }
        public MaterialAddDtoValidator MaterialAddDtoValidator { get; }
        public MaterialEditDtoValidator MaterialEditDtoValidator { get; }
        public CompanyAddDtoValidator CompanyAddDtoValidator { get; }
        public CompanyEditDtoValidator CompanyEditDtoValidator { get; }
        public OfferAddDtoValidator OfferAddDtoValidator { get; }
        public OfferEditDtoValidator OfferEditDtoValidator { get; }
    }
}