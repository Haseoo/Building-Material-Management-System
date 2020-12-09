using com.Github.Haseoo.BMMS.Data.Repositories.Adapters;
using com.Github.Haseoo.BMMS.Data.Repositories.Ports;
using NHibernate;
using System;

namespace com.Github.Haseoo.BMMS.Data.Repositories
{
    public class RepositoryContext : IDisposable
    {
        private bool _disposed = false;
        private readonly ISession _session;

        public RepositoryContext(ISessionFactory sessionFactory)
        {
            _session = sessionFactory.OpenSession();
            CompanyRepository = new CompanyRepository(_session);
            OfferRepository = new OfferRepository(_session);
            MaterialRepository = new MaterialRepository(_session);
        }


        public ICompanyRepository CompanyRepository { get; }
        public IOfferRepository OfferRepository { get; }
        public IMaterialRepository MaterialRepository { get; }

        public ITransaction BeginTransaction()
        {
            return _session.BeginTransaction();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _session.Dispose();
            }

            _disposed = true;
        }
    }
}