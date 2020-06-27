using com.Github.Haseoo.BMMS.Data.Entities;
using FluentNHibernate.Mapping;

namespace com.Github.Haseoo.BMMS.Data.Mappings
{
    public class MaterialMap : EntityMap<Material>
    {
        public MaterialMap()
        {
            Table("MATERIALS");
            Map(x => x.Name,
                    "NAME")
                .Not.Nullable();
            Map(x => x.Specification,
                    "SPECIFICATION")
                .Not.Nullable();
        }
    }
}