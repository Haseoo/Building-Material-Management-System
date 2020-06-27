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
            Map(x => x.Name);
            Map(x => x.Address);
            HasMany(x => x.ContactData)
                .KeyColumn("companyId")
                .Not.KeyNullable()
                .Not.KeyUpdate()
                .Not.Inverse()
                .Cascade.All();
        }
    }
}