using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Television : Item
    {
        public string Size { get; set; }
        public string Manufacturer { get; set; }

        public string PrintInfo()
        {
            return $"{Manufacturer} - {Size}";
        }
    }
}
