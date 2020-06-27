using com.Github.Haseoo.BMMS.Data.Entities;

namespace com.Github.Haseoo.BMMS.Data.Mappings
{
    public class OfferMap : EntityMap<Offer>
    {
        public OfferMap()
        {
            Table("OFFERS");
            Map(x => x.Unit);
            Map(x => x.UnitPrice);
            Map(x => x.Comments);
            Map(x => x.LastModification);

            References(x => x.Company).Column("companyId");
            References(x => x.Material).Column("materialId");
        }
    }
}