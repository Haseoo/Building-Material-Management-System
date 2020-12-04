using com.Github.Haseoo.BMMS.Data.Entities;
using System;
using System.Linq;

namespace com.Github.Haseoo.BMMS.Data.Repositories.Ports
{
    public interface IBaseRepository<T> where T : Entity
    {
        IQueryable<T> GetAll();

        T GetById(Guid id);

        T Add(in T entity);

        T Update(in T entity);

        void Remove(in Entity entity);
    }
}