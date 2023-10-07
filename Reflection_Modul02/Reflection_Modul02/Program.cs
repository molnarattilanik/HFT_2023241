using System;

namespace Reflection_Modul02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Person person = new Person() { Name = "Attilaaaaaaaaaaaaaaaaaaa", Age = 28 };
            Person person1 = new Person() { Name = "András", Age = 101 };
            Person person2 = new Person() { Name = "Elemér", Age = 28 };

            Validator validator = new Validator();

            Console.WriteLine($"Is Person valid: {validator.Validate(person)}");
            Console.WriteLine($"Is Person valid: {validator.Validate(person1)}");
            Console.WriteLine($"Is Person valid: {validator.Validate(person2)}");
        }
    }
}
