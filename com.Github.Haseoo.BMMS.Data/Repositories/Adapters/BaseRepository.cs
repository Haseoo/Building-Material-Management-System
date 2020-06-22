using System;
using System.Collections.Generic;
using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories.Ports;

namespace com.Github.Haseoo.BMMS.Data.Repositories.Adapters
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T:Entity
    {
        private readonly Dictionary<Guid, T> _storage;

        protected BaseRepository(Dictionary<Guid, T> storage)
        {
            _storage = storage;
        }

        public IEnumerable<T> GetAll()
        {
            return _storage.Values;
        }

        public T GetById(Guid id)
        {
            return _storage[id];
        }

        public void Add(in T entity)
        {
            _storage.Add(entity.Id, entity);
        }

        public void Remove(in Guid id)
        {
            _storage.Remove(id);
        }

        protected abstract T copyEntity(T newEntity, T oldEntity);
    }
}