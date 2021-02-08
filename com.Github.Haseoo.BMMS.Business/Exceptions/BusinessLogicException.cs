
using System;

namespace com.Github.Haseoo.BMMS.Business.Exceptions
{
    [Serializable]
    public class BusinessLogicException: Exception
    {
        public BusinessLogicException(string name) :  base($"{name} not found")
        {
        }
    }
}
