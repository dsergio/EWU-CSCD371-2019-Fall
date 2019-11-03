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
            Person p = new Person
            {
                FirstName = "David",
                LastName = "Sergio"
            };
            Mailbox mailbox = new Mailbox(Sizes.Large, (2, 3), p);

            // Act
            string str = mailbox.ToString();

            // Assert
            Assert.AreEqual(str, "Large (2, 3) David Sergio");
        }
    }
}
