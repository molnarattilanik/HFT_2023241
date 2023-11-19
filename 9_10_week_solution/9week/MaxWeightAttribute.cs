using System;
using System.ComponentModel.DataAnnotations;

namespace _9week
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MaxWeightAttribute : ValidationAttribute
    {
        public double MaxWeight { get; set; }
        
        public MaxWeightAttribute(double maxWeight)
        {
            MaxWeight = maxWeight;
        }
    }
}
