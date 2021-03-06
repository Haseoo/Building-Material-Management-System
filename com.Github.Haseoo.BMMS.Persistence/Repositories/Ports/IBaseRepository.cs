﻿using com.Github.Haseoo.BMMS.Data.Entities;
using System;
using System.Linq;

namespace com.Github.Haseoo.BMMS.Data.Repositories.Ports
{
    public interface IBaseRepository<T> where T : Entity
    {
        IQueryable<T> GetAll();

        T GetById(Guid id);

        T Add(T entity);

        T Update(T entity);

        void Remove(Entity entity);
    }
}