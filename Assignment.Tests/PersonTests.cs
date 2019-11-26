using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Assignment.Tests
{
    [TestClass]
    public class PersonTests
    {
        [DataTestMethod]
        [DataRow("first")]
        [DataRow("last")]
        [DataRow("address")]
        [DataRow("email")]
        [ExpectedException(typeof(ArgumentNullException))]
        [ExcludeFromCodeCoverage]
        public void Person_CreatePersonInvalid_ThrowsException(string type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            // Arrange

            // Act
            _ = new Person(
                type == "first" ? null! : "first",
                type == "last" ? null! : "last",
                type == "address" ? null! : new Address("street", "city", "state", "zip"),
                type == "email" ? null! : "email"
                );

            // Assert
        }
    }
}
