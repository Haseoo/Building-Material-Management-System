using com.Github.Haseoo.BMMS.Data.Repositories.Adapters;
using com.Github.Haseoo.BMMS.Data.Repositories.Ports;

namespace com.Github.Haseoo.BMMS.Data.Repositories
{
    public class RepositoryContext
    {

        public RepositoryContext()
        {
            CompanyRepository = new CompanyRepository();
            OfferRepository = new OfferRepository();
            MaterialRepository = new MaterialRepository();
        }

        public ICompanyRepository CompanyRepository { get; }
        public IOfferRepository OfferRepository { get; }
        public IMaterialRepository MaterialRepository { get; }
    }


}