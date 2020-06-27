using System;
using System.Collections.Generic;
using com.Github.Haseoo.BMMS.Data.Entities;

namespace com.Github.Haseoo.BMMS.Data.Repositories.Ports
{
    public interface IBaseRepository<T> where T : Entity
    {
        IList<T> GetAll();
        T GetById(Guid id);
        T Add(in T entity);
        T Update(in T entity);
        void Remove(in Entity entity);
    }
}