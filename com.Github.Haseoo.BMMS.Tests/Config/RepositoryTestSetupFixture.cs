using NHibernate;
using NUnit.Framework;

namespace com.Github.Haseoo.BMMS.Tests.Config
{
    [SetUpFixture]
    public abstract class RepositoryTestSetupFixture
    {
        protected ISession _session;
        protected ITransaction _transaction;

        [SetUp]
        public virtual void Setup()
        {
            InMemorySessionFactoryProvider.Instance.Initialize();
            _session = InMemorySessionFactoryProvider.Instance.OpenSession();
            _transaction = _session.BeginTransaction();
        }

        [TearDown]
        public virtual void TestTeardown()
        {
            InMemorySessionFactoryProvider.Instance.Dispose();
            if (_transaction.IsActive) _transaction.Rollback();
            _session.Close();
        }
    }
}