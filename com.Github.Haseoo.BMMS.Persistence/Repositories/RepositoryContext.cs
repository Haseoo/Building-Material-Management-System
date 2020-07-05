﻿using com.Github.Haseoo.BMMS.Data.Repositories.Adapters;
using com.Github.Haseoo.BMMS.Data.Repositories.Ports;
using NHibernate;

namespace com.Github.Haseoo.BMMS.Data.Repositories
{
    public class RepositoryContext
    {
        private readonly SessionWrapper _sessionWrapper;

        public RepositoryContext(SessionWrapper sessionWrapper)
        {
            _sessionWrapper = sessionWrapper;
            CompanyRepository = new CompanyRepository(sessionWrapper);
            OfferRepository = new OfferRepository(sessionWrapper);
            MaterialRepository = new MaterialRepository(sessionWrapper);
        }

        public void SetSession(ISession session)
        {
            _sessionWrapper.Session = session;
        }

        public ICompanyRepository CompanyRepository { get; }
        public IOfferRepository OfferRepository { get; }
        public IMaterialRepository MaterialRepository { get; }
    }
}