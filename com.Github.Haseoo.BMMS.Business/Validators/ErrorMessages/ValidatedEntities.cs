using System.ComponentModel;

namespace com.Github.Haseoo.BMMS.Business.Validators.ErrorMessages
{
    public enum ValidatedEntities
    {
        [Description("Company")]
        Company,

        [Description("Material")]
        Material,

        [Description("Company contact")]
        CompanyContactData,

        [Description("Offer")]
        Offer
    }
}