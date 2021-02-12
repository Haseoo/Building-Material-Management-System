using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Github.Haseoo.BMMS.Business.Services.Ports
{
    public interface ITransactionalService<T, R>
    {
        R Add(T operation);
        void Delete(Guid id);
    }
}
