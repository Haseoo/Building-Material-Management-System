
using System;
using System.Runtime.Serialization;

namespace com.Github.Haseoo.BMMS.Business.Exceptions
{
    [Serializable]
    public class NotFoundException: BusinessLogicException
    {
        public NotFoundException(string name) :  base($"{name} not found")
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context): base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
