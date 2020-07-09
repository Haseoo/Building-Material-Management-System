using com.Github.Haseoo.BMMS.Business.Validators.ErrorMessages;
using System;
using System.ComponentModel;

namespace com.Github.Haseoo.BMMS.Business.Extensions
{
    public static class ValidatedEntitiesExtension
    {
        public static string GetDescription(this ValidatedEntities value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name == null)
            {
                return null;
            }
            var field = type.GetField(name);
            if (field == null)
            {
                return null;
            }
            if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attr)
            {
                return attr.Description;
            }
            return null;
        }
    }
}