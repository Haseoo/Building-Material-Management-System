using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.Github.Haseoo.BMMS.Data;
using NHibernate;

namespace com.Github.Haseoo.BMMS.Business.Services.Adapters
{
    public abstract class TransactionalService<T, R>
    {
        public R Add(T operation)
        {
            ITransaction transaction = null;
            try
            {
                transaction = SessionManager.Instance.GetSession().BeginTransaction();
                var returnValue = DoAdd(operation);
                transaction.Commit();
                return returnValue;
            }
            catch
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                }
                throw;
            }
        }

        public void Delete(Guid id)
        {
            ITransaction transaction = null;
            try
            {
                transaction = SessionManager.Instance.GetSession().BeginTransaction();
                DoDelete(id);
                transaction.Commit();
            }
            catch
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                }
                throw;
            }
        }

        protected abstract R DoAdd(T operation);

        protected abstract void DoDelete(Guid id);
    }
}
