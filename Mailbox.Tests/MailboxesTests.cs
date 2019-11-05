using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxesTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Mailboxes_ArgumentOutOfRange_ThrowsException()
        {
            // Arrange
            Person p1 = new Person("David", "Sergio");
            Mailbox m1 = new Mailbox(Sizes.Medium, (1, 1), p1);
            List<Mailbox> listMailBoxes = new List<Mailbox>
            {
                m1
            };

            // Act
            _ = new Mailboxes(listMailBoxes, -1, 1);

            // Assert

        }

        [TestMethod]
        public void Mailboxes_GetAdjacentPeople_ReturnsOccupied()
        {
            // Arrange
            Person p1 = new Person("David", "Sergio");
            Mailbox m1 = new Mailbox(Sizes.Medium, (0, 0), p1);
            List<Mailbox> listMailBoxes = new List<Mailbox>
            {
                m1
            };

            // Act
            Mailboxes mailBoxes = new Mailboxes(listMailBoxes, 1, 1);
            bool occupied = mailBoxes.GetAdjacentPeople(0, 0, out HashSet<Person> _);

            // Assert
            Assert.IsTrue(occupied);
        }

        [TestMethod]
        public void Mailboxes_GetAdjacentPeopleValid_ReturnsNotOccupied()
        {
            // Arrange
            Person p1 = new Person("David", "Sergio");
            Mailbox m1 = new Mailbox(Sizes.Medium, (0, 0), p1);
            List<Mailbox> listMailBoxes = new List<Mailbox>
            {
                m1
            };

            // Act
            Mailboxes mailBoxes = new Mailboxes(listMailBoxes, 10, 10);
            bool occupied = mailBoxes.GetAdjacentPeople(5, 5, out HashSet<Person> _);

            // Assert
            Assert.IsFalse(occupied);
        }
    }
}
