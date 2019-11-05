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
        public void Person_EqualsMethod_ReturnsTrue()
        {
            // Arrange
            Person p1 = new Person("David", "Sergio");
            Person p2 = new Person("David", "Sergio");

            // Act
            bool equalsRet = p1.Equals(p2);

            // Assert
            Assert.IsTrue(equalsRet);
        }

        [TestMethod]
        public void Person_EqualsMethod_ReturnsFalse()
        {
            // Arrange
            Person p1 = new Person("David", "Sergio");
            Person p2 = new Person("David", "Duchovny");

            // Act
            bool equalsRet = p1.Equals(p2);

            // Assert
            Assert.IsFalse(equalsRet);
        }

        [TestMethod]
        public void Person_EqualsOperatorTrue_ReturnsTrue()
        {
            // Arrange
            Person p1 = new Person("David", "Sergio");
            Person p2 = new Person("David", "Sergio");

            // Act
            bool equalsRet = (p1 == p2);

            // Assert
            Assert.IsTrue(equalsRet);
        }

        [TestMethod]
        public void Person_EqualsOperatorFalse_ReturnsTrue()
        {
            // Arrange
            Person p1 = new Person("David", "Sergio");
            Person p2 = new Person("David", "Duchovny");

            // Act
            bool equalsRet = p1 != p2;

            // Assert
            Assert.IsTrue(equalsRet);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("david", null)]
        [DataRow(null, "schwimmer")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Person_InvalidName_ThrowsException(string firstName, string lastName)
        {
            // Arrange

            // Act
            Person p = new Person(firstName, lastName);

            // Assert
        }
    }
}
