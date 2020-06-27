using com.Github.Haseoo.BMMS.Data.Entities;
using FluentNHibernate.Mapping;

namespace com.Github.Haseoo.BMMS.Data.Mappings
{
    public class MaterialMap : EntityMap<Material>
    {
        public MaterialMap()
        {
            Table("MATERIALS");
            Map(x => x.Name);
            Map(x => x.Specification);
        }
    }
}