using com.Github.Haseoo.BMMS.Data.Entities;

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
            HasMany(x => x.Offers)
                .Cascade.DeleteOrphan()
                .Fetch.Join().LazyLoad()
                .Inverse().KeyColumn("MATERIAL_ID");
        }
    }
}