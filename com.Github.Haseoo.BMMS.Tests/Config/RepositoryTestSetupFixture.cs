using System;
using NHibernate;
using NUnit.Framework;

namespace com.Github.Haseoo.BMMS.Tests.Config
{
    public abstract class RepositoryTestSetupFixture
    {
        protected ISession _session;
        protected ITransaction _transaction;

        public virtual void Setup()
        {
            InMemorySessionFactoryProvider.Instance.Initialize();
            _session = InMemorySessionFactoryProvider.Instance.OpenSession();
            _transaction = _session.BeginTransaction();
        }

        public virtual void TestTeardown()
        {
            if (_transaction.IsActive) _transaction.Rollback();
            _session.Close();
            InMemorySessionFactoryProvider.Instance.Dispose();
        }
    }
}