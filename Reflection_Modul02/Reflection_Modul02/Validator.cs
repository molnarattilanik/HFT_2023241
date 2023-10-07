using System.Reflection;

namespace Reflection_Modul02
{
    internal class Validator
    {
        public bool Validate(object instance)
        {
            ValidationFactory validationFactory = new();
            var propertyInfoArray = instance.GetType().GetProperties();

            foreach (var propertyInfo in propertyInfoArray)
            {
                var attributes = propertyInfo.GetCustomAttributes();
                foreach (var attribute in attributes)
                {
                    var validation = validationFactory.GetValidator(attribute);
                    if (validation?.Validate(instance, propertyInfo) == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
