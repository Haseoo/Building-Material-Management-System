
using System;

namespace com.Github.Haseoo.BMMS.Business.Exceptions
{
    [Serializable]
    public class BusinessLogicException: Exception
    {
        public BusinessLogicException(string message) :  base(message)
        {
        }
    }
}
