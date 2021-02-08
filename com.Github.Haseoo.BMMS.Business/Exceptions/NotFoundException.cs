
using System;

namespace com.Github.Haseoo.BMMS.Business.Exceptions
{
    [Serializable]
    public class NotFoundException: BusinessLogicException
    {
        public NotFoundException(string name) :  base($"{name} not found")
        {
        }
    }
}
