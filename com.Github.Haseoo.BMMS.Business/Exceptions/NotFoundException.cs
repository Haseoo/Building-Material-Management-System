
using System;

namespace com.Github.Haseoo.BMMS.Business.Exceptions
{
    [Serializable]
    public class NotFoundException: Exception
    {
        public NotFoundException(string name) :  base($"{name} not found")
        {
        }
    }
}
