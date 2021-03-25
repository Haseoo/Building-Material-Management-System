using System;

namespace com.Github.Haseoo.BMMS.Business.Services.Ports
{
    public interface ITransactionalService<in T, out R>
    {
        R Add(T operation);

        void Delete(Guid id);
    }
}