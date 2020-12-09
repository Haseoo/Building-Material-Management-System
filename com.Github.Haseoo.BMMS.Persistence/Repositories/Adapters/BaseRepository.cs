using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories.Ports;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;

namespace com.Github.Haseoo.BMMS.Data.Repositories.Adapters
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        private readonly ISession _session;

        protected BaseRepository(ISession session)
        {
            _session = session;
        }

        public IQueryable<T> GetAll()
        {
            return _session.Query<T>();
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