using com.Github.Haseoo.BMMS.Data.Repositories.Adapters;
using com.Github.Haseoo.BMMS.Data.Repositories.Ports;
using NHibernate;

namespace com.Github.Haseoo.BMMS.Data.Repositories
{
    public class RepositoryContext
    {
        public RepositoryContext(ISession session)
        {
            Session = session;
            CompanyRepository = new CompanyRepository(session);
            OfferRepository = new OfferRepository(session);
            MaterialRepository = new MaterialRepository(session);
        }

        private ISession Session { get; set; }
        public ICompanyRepository CompanyRepository { get;}
        public IOfferRepository OfferRepository { get;}
        public IMaterialRepository MaterialRepository { get;}
        
    }
}