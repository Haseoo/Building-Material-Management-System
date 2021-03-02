
using System;
using System.Runtime.Serialization;

namespace com.Github.Haseoo.BMMS.Business.Exceptions
{
    [Serializable]
    public class BusinessLogicException: Exception
    {

        public BusinessLogicException(string message) :  base(message)
        {
        }

        protected BusinessLogicException(SerializationInfo info, StreamingContext context): base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
