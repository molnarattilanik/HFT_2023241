using System;
using System.Reflection;

namespace Reflection_Modul02
{
    public interface IValidate
    {
        bool Validate(object obj, PropertyInfo propertyInfo);
    }

    internal class MaxLengthValidation : IValidate
    {
        private readonly MaxLengthAttribute maxLengthAttribute;

        public MaxLengthValidation(MaxLengthAttribute maxLengthAttribute)
        {
            this.maxLengthAttribute = maxLengthAttribute;
        }

        public bool Validate(object obj, PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType == typeof(string))
            {
                var value = (string)propertyInfo.GetValue(obj);
                return value.Length <= maxLengthAttribute.Length;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }

    internal class RangeValidation : IValidate
    {
        private readonly RangeAttribute rangeAttribute;

        public RangeValidation(RangeAttribute rangeAttribute)
        {
            this.rangeAttribute = rangeAttribute;
        }

        public bool Validate(object obj, PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType == typeof(int))
            {
                var value = (int)propertyInfo.GetValue(obj);
                return value >= rangeAttribute.Min && value <= rangeAttribute.Max;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
