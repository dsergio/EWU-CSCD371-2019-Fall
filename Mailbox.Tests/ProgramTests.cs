using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Program_GetOwnersDisplay_ReturnsCorrectData()
        {
            // Arrange
            Person p1 = new Person("David", "Sergio");
            Person p2 = new Person("David", "Duchovny");
            Mailbox m1 = new Mailbox(Sizes.Medium, (1, 2), p1);
            Mailbox m2 = new Mailbox(Sizes.Medium, (2, 3), p1);
            Mailbox m3 = new Mailbox(Sizes.Medium, (2, 3), p2);
            Mailbox m4 = new Mailbox(Sizes.Medium, (2, 3), p2);
            List<Mailbox> listMailBoxes = new List<Mailbox>();
            listMailBoxes.Add(m1);
            listMailBoxes.Add(m2);
            listMailBoxes.Add(m3);
            listMailBoxes.Add(m4);
            Mailboxes mailBoxes = new Mailboxes(listMailBoxes, 10, 30);

            // Act
            string str = Program.GetOwnersDisplay(mailBoxes);

            // Assert
            Assert.AreEqual(str, "David Sergio, David Duchovny");
        }

        [TestMethod]
        public void Program_GetMailboxDetails_ReturnsCorrectData()
        {
            // Arrange
            Person p1 = new Person("David", "Sergio");
            Person p2 = new Person("David", "Duchovny");
            Mailbox m1 = new Mailbox(Sizes.Medium, (1, 2), p1);
            Mailbox m2 = new Mailbox(Sizes.Medium, (2, 3), p2);
            List<Mailbox> listMailBoxes = new List<Mailbox>();
            listMailBoxes.Add(m1);
            listMailBoxes.Add(m2);
            Mailboxes mailBoxes = new Mailboxes(listMailBoxes, 10, 30);

            // Act
            string str = Program.GetMailboxDetails(mailBoxes, 1, 2);

            // Assert
            Assert.AreEqual(str, "Medium (1, 2) David Sergio");
        }
    }
}
