using System.Linq;
using System.Collections.Generic;

namespace Assignment
{
    public class Person : IPerson
    {
        public Person(string firstName, string lastName, IAddress address, string emailAddress)
        {
            FirstName = firstName ?? throw new System.ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new System.ArgumentNullException(nameof(lastName));
            Address = address ?? throw new System.ArgumentNullException(nameof(address));
            EmailAddress = emailAddress ?? throw new System.ArgumentNullException(nameof(emailAddress));
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IAddress Address { get;set; }
        public string EmailAddress { get; set; }
    }
}
