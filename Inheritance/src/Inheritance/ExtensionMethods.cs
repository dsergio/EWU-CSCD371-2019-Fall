using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public static class ActorExtensionMethods
    {

        public static string Speak(this Actor actor) =>
            actor switch 
            {
                Raj { WomenArePresent: false } raj => raj.GetWords(),
                Raj { WomenArePresent: true } raj => raj.Mumble(),
                Sheldon sheldon => sheldon.GetWords(),
                Penny penny => penny.GetWords(),
                { } => throw new ArgumentException("bad arg"),
                null => throw new ArgumentNullException(nameof(actor))
            };
   
    }
}
