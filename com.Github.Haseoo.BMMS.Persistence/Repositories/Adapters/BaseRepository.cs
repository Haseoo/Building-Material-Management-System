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

        protected BaseRepository()
        {
        }

        public IQueryable<T> GetAll()
        {
            return SessionManager.Instance.GetSession().Query<T>();
        }

        public T GetById(Guid id)
        {
            return SessionManager.Instance.GetSession().Get<T>(id);
        }

        public T Add(T entity)
        {
            var id = SessionManager.Instance.GetSession().Save(entity);
            return SessionManager.Instance.GetSession().Get<T>(id);
        }

        public T Update(T entity)
        {
            SessionManager.Instance.GetSession().Update(entity);
            SessionManager.Instance.GetSession().Flush();
            return entity;
        }

        public void Remove(Entity entity)
        {
            SessionManager.Instance.GetSession().Delete(entity);
        }
    }
}