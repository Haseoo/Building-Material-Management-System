using com.Github.Haseoo.BMMS.Data.Repositories.Ports;

namespace com.Github.Haseoo.BMMS.Data.Repositories
{
    public class RepositoryContext
    {
        public ICompanyRepository CompanyRepository { get; set; }
        public IOfferRepository OfferRepository { get; set; }
        public IMaterialRepository MaterialRepository { get; set; }
    }
}