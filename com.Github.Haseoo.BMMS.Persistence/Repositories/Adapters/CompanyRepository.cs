using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories.Ports;
using NHibernate;

namespace com.Github.Haseoo.BMMS.Data.Repositories.Adapters
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
    }
}