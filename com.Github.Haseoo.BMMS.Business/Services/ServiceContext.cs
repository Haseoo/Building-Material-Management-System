using AutoMapper;
using com.Github.Haseoo.BMMS.Business.Services.Adapters;
using com.Github.Haseoo.BMMS.Business.Services.Ports;
using com.Github.Haseoo.BMMS.Data.Repositories;
using NHibernate;
using System;

namespace com.Github.Haseoo.BMMS.Business.Services
{
    public class ServiceContext : IDisposable
    {
        private readonly RepositoryContext _repositoryContext;
        private bool _disposed = false;

        public IMaterialService MaterialService { get; }

        public ServiceContext(ISessionFactory sessionFactory,
            IMapper mapper)
        {
            _repositoryContext = new RepositoryContext(sessionFactory);
            MaterialService = new MaterialService(_repositoryContext.MaterialRepository, mapper);
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
                _repositoryContext.Dispose();
            }

            _disposed = true;
        }
    }
}
