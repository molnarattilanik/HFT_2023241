using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10thWeek
{
    internal class DataDescriptionAttribute : Attribute
    {
        public string Description { get; set; }

        public DataDescriptionAttribute(string description)
        {
            this.Description = description;
        }
    }
}
