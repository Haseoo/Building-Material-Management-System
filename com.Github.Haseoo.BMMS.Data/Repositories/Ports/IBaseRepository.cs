using System;
using System.Collections.Generic;
using com.Github.Haseoo.BMMS.Data.Entities;

namespace com.Github.Haseoo.BMMS.Data.Repositories.Ports
{
    public interface IBaseRepository <T> where T:Entity
    {
        IEnumerable<T> GetAll();
        T GetById( Guid id);
        void Add(in T entity);
        void Edit(in Guid id, in T newEntity);
        void Remove(in Guid id);
    }
}