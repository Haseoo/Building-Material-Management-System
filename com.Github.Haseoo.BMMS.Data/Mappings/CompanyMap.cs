using com.Github.Haseoo.BMMS.Data.Entities;
using FluentNHibernate.MappingModel.Collections;
using NHibernate.Mapping;

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
            HasMany(x => x.ContactData)
                .KeyColumn("COMPANY_ID")
                .Not.KeyNullable()
                .Not.KeyUpdate()
                .Not.Inverse()
                .Cascade.All();
        }
    }
}