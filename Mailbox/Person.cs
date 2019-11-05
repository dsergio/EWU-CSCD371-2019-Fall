﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        public string FirstName { get;  }
        public string LastName { get; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Person p)
            {
                return Equals(p);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (FirstName, LastName).GetHashCode();
        }

        public bool Equals([AllowNull] Person other)
        {
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public static bool operator ==(Person a, Person b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Person a, Person b)
        {
            return !(a == b);
        }
    }
}