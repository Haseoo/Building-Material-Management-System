using System;
using System.Collections.Generic;
using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories.Ports;
using NHibernate;

namespace com.Github.Haseoo.BMMS.Data.Repositories.Adapters
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(ISession session) : base(session)
        {
        }
    }
}