using System.ComponentModel;

namespace com.Github.Haseoo.BMMS.Business.Validators.ErrorMessages
{
    public enum ValidatedEntities
    {
        [Description("company")]
        Company,

        [Description("material")]
        Material,

        [Description("company contact: ")]
        CompanyContactData,

        [Description("offer")]
        Offer,

        [Description("order list: ")]
        OrderList,

        [Description("order position")]
        OrderPosition
    }
}