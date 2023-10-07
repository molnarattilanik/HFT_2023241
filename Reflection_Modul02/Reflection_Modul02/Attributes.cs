using System;

namespace Reflection_Modul02
{
    internal sealed class RangeAttribute : Attribute
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public RangeAttribute(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }

    internal sealed class MaxLengthAttribute : Attribute
    {
        public int Length { get; set; }

        public MaxLengthAttribute(int max)
        {
            Length = max;
        }
    }
}
