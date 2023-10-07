namespace Reflection_Modul02
{
    internal sealed class Person
    {
        [MaxLength(10)]
        public string Name { get; set; }

        [Range(0, 99)]
        public int Age { get; set; }
    }
}
