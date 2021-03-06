﻿using com.Github.Haseoo.BMMS.Data.Entities;

namespace com.Github.Haseoo.BMMS.Data.Mappings
{
    public class CompanyMap : EntityMap<Company>
    {
        public CompanyMap()
        {
            Table("COMPANIES");
            Map(x => x.Name,
                    "NAME")
                .CustomSqlType("text")
                .Not.Nullable();
            Map(x => x.Address,
                    "ADDRESS")
                .CustomSqlType("text")
                .Not.Nullable();
            Map(x => x.City,
                    "CITY")
                .CustomSqlType("text")
                .Not.Nullable();
            Map(x => x.Voivodeship,
                    "VOIVODESHIP")
                .CustomSqlType("text")
                .Not.Nullable();
            HasMany(x => x.Offers)
                .Cascade.DeleteOrphan()
                .Fetch.Join().LazyLoad()
                .Inverse().KeyColumn("COMPANY_ID");

            HasMany(x => x.ContactData)
                .KeyColumn("COMPANY_ID")
                .ForeignKeyConstraintName("C_DATA_COMPANY_FK")
                .Not.KeyNullable()
                .Not.KeyUpdate()
                .Not.Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}