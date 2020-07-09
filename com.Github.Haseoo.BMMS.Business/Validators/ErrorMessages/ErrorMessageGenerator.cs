using com.Github.Haseoo.BMMS.Business.Extensions;

namespace com.Github.Haseoo.BMMS.Business.Validators.ErrorMessages
{
    public static class ErrorMessageGenerator
    {
        public static string GetEmptyValidationErrorMessage(ValidatedEntities validatedEntity)
        {
            return $"{validatedEntity.GetDescription()} {{PropertyName}} cannot be empty";
        }
    }
}