using com.Github.Haseoo.BMMS.Data.Entities;
using FluentNHibernate.Mapping;

namespace com.Github.Haseoo.BMMS.Data.Mappings
{
    public class EntityMap<T> : ClassMap<T> where T : Entity
    {
        public EntityMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
        }
    }
}