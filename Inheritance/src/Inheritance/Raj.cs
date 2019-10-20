using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Raj : Actor
    {
        public bool WomenArePresent { get; set; }

        public string Mumble() => "mumble mumble";

        public string GetWords() => "I am Raj";
    }
}
