﻿using com.Github.Haseoo.BMMS.Business.Services.Ports;
using com.Github.Haseoo.BMMS.Data;
using NHibernate;
using System;

namespace com.Github.Haseoo.BMMS.Business.Services.Adapters
{
    public class TransactionalService<T, R> : ITransactionalService<T, R>
    {
        private readonly ITransactionalService<T, R> _service;

        public TransactionalService(ITransactionalService<T, R> service)
        {
            _service = service;
        }

        public R Add(T operation)
        {
            ITransaction transaction = null;
            try
            {
                transaction = SessionManager.Instance.GetSession().BeginTransaction();
                var returnValue = _service.Add(operation);
                transaction.Commit();
                transaction.Dispose();
                return returnValue;
            }
            catch
            {
                transaction?.Rollback();
                throw;
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        public void Delete(Guid id)
        {
            ITransaction transaction = null;
            try
            {
                transaction = SessionManager.Instance.GetSession().BeginTransaction();
                _service.Delete(id);
                transaction.Commit();
                transaction.Dispose();
            }
            catch
            {
                transaction?.Rollback();
                throw;
            }
            finally
            {
                transaction?.Dispose();
            }
        }
    }
}