using System;

namespace Reflection_Modul02
{
    internal class ValidationFactory
    {
        public IValidate GetValidator(Attribute attribute)
        {
            if (attribute is RangeAttribute rangeAttribute)
            {
                return new RangeValidation(rangeAttribute);
            }

            if (attribute is MaxLengthAttribute maxLength)
            {
                return new MaxLengthValidation(maxLength);
            }

            return null;
        }
    }
}
