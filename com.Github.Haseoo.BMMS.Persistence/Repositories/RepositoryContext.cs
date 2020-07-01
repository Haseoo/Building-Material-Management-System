using com.Github.Haseoo.BMMS.Data.Repositories.Adapters;
using com.Github.Haseoo.BMMS.Data.Repositories.Ports;
using NHibernate;

namespace com.Github.Haseoo.BMMS.Data.Repositories
{
    public class RepositoryContext
    {
        public RepositoryContext(SessionWrapper sessionWrapper)
        {
            _sessionWrapper = sessionWrapper;
            CompanyRepository = new CompanyRepository(sessionWrapper);
            OfferRepository = new OfferRepository(sessionWrapper);
            MaterialRepository = new MaterialRepository(sessionWrapper);
        }

        private readonly SessionWrapper _sessionWrapper;

        public ISession Session
        {
            set => _sessionWrapper.Session = value;
        }
        public ICompanyRepository CompanyRepository { get; }
        public IOfferRepository OfferRepository { get; }
        public IMaterialRepository MaterialRepository { get; }
    }
}