using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxTests
    {
        [TestMethod]
        public void Mailbox_ToString_ReturnsCorrectValue()
        {
            // Arrange
            Person p = new Person("David", "Sergio");
            Mailbox mailbox = new Mailbox(Sizes.Large, (2, 3), p);

            // Act
            string str = mailbox.ToString();

            // Assert
            Assert.AreEqual(str, "Large (2, 3) David Sergio");
        }

        [TestMethod]
        public void Mailbox_PremiumToString_ReturnsCorrectValue()
        {
            // Arrange
            Person p = new Person("David", "Sergio");
            Mailbox mailbox = new Mailbox(Sizes.Large | Sizes.Premium, (2, 3), p);

            // Act
            string str = mailbox.ToString();

            // Assert
            Assert.AreEqual(str, "Large, Premium (2, 3) David Sergio");
        }

        [DataTestMethod]
        [DataRow(Sizes.Small | Sizes.Medium)]
        [DataRow(Sizes.Premium)]
        [DataRow(Sizes.Small | Sizes.Large)]
        [DataRow(Sizes.Large | Sizes.Medium)]
        [ExpectedException(typeof(ArgumentException))]
        public void Mailbox_NewMailboxInvalidData_ThrowsException(Sizes size)
        {
            // Arrange
            Person p = new Person("David", "Duchovny");
            

            // Act
            Mailbox mailbox = new Mailbox(size, (2, 3), p);

            // Assert

        }
    }
}
