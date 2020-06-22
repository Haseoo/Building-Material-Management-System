using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public IList<T> GetAll()
        {
            return _storage.Values.ToList();
        }

        public T GetById(Guid id)
        {
            return _storage.ContainsKey(id) ? _storage[id] : null;
        }

        public void Add(in T entity)
        {
            _storage.Add(entity.Id, entity);
        }

        public void Remove(in Guid id)
        {
            _storage.Remove(id);
        }
    }
}