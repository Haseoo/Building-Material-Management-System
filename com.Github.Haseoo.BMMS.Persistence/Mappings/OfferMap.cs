﻿using com.Github.Haseoo.BMMS.Data.Entities;

namespace com.Github.Haseoo.BMMS.Data.Mappings
{
    public class OfferMap : EntityMap<Offer>
    {
        public OfferMap()
        {
            Table("OFFERS");
            Map(x => x.Unit,
                    "UNIT")
                .CustomSqlType("TEXT")
                .Not.Nullable();
            Map(x => x.UnitPrice,
                    "UNIT_PRICE")
                .Precision(10)
                .Scale(2)
                .Not.Nullable();
            Map(x => x.Comments,
                    "COMMENTS")
                .CustomSqlType("TEXT");
            Map(x => x.LastModification,
                "LAST_MODIFICATION_DATE");

            HasMany(x => x.OrderPositions)
                .Cascade.DeleteOrphan()
                .Fetch.Join().LazyLoad()
                .Inverse().KeyColumn("OFFER_ID");

            References(x => x.Company)
                .Column("COMPANY_ID")
                .ForeignKey("OFFER_COMPANY_FK")
                .Not.Nullable();

            References(x => x.Material)
                .Column("MATERIAL_ID")
                .ForeignKey("OFFER_MATERIAL_FK")
                .Not.Nullable();

            CheckConstraint("UNIT_PRICE >= 0");
        }
    }
}