using System;
using System.Collections.Generic;
using System.Linq;
using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories.Ports;
using NHibernate;

namespace com.Github.Haseoo.BMMS.Data.Repositories.Adapters
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        private readonly ISession _session;

        protected BaseRepository(ISession session)
        {
            _session = session;
        }

        public IList<T> GetAll()
        {
            return _session.CreateCriteria<T>().List<T>();
        }

        public T GetById(Guid id)
        {
            return _session.Get<T>(id);
        }

        public T Add(in T entity)
        {
            var id = _session.Save(entity);
            return _session.Get<T>(id);
        }

        public T Update(in T entity)
        {
            _session.Update(entity);
            return entity;
        }

        public void Remove(in Entity entity)
        {
            _session.Delete(entity);
        }
    }
}