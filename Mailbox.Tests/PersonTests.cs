using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Person_EqualsOperator_ReturnsTrue()
        {
            // Arrange
            Person p1 = new Person
            {
                FirstName = "David",
                LastName = "Sergio"
            };
            Person p2 = new Person
            {
                FirstName = "David",
                LastName = "Sergio"
            };

            // Act
            bool equalsRet = p1.Equals(p2);

            // Assert
            Assert.IsTrue(equalsRet);
        }

        [TestMethod]
        public void Person_EqualsOperator_ReturnsFalse()
        {
            // Arrange
            Person p1 = new Person
            {
                FirstName = "David",
                LastName = "Sergio"
            };
            Person p2 = new Person
            {
                FirstName = "David",
                LastName = "Duchovny"
            };

            // Act
            bool equalsRet = p1.Equals(p2);

            // Assert
            Assert.IsFalse(equalsRet);
        }
    }
}
