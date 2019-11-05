using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class DataLoaderTests
    {
        [TestMethod]
        public void DataLoader_NonJSON_ReturnsNull()
        {
            // Arrange
            MemoryStream memoryStream = new MemoryStream();
            using var writer = new StreamWriter(memoryStream);
            writer.WriteLine("this is not JSON");
            writer.Flush();

            DataLoader dataLoader = new DataLoader(memoryStream);

            // Act
            var mailBoxes = dataLoader.Load();

            // Assert
            Assert.IsNull(mailBoxes);

        }

        [TestMethod]
        public void DataLoader_ValidData_ReturnsMailboxes()
        {
            // Arrange
            MemoryStream memoryStream = new MemoryStream();
            using var writer = new StreamWriter(memoryStream);

            Person p1 = new Person("David", "Sergio");
            Mailbox m1 = new Mailbox(Sizes.Medium, (1,2), p1);
            Mailbox m2 = new Mailbox(Sizes.Medium, (2, 3), p1);
            List<Mailbox> listMailBoxes = new List<Mailbox>();
            listMailBoxes.Add(m1);
            listMailBoxes.Add(m2);
            Mailboxes mailBoxes = new Mailboxes(listMailBoxes, 10, 30);
            foreach (Mailbox m in listMailBoxes)
            {
                string str = JsonConvert.SerializeObject(m);
                Console.WriteLine("writing " + str);
                writer.WriteLine(str);
            }
            writer.Flush();
            memoryStream.Position = 0;
            DataLoader dataLoader = new DataLoader(memoryStream);

            //Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            //Trace.AutoFlush = true;
            //Trace.WriteLine(JsonConvert.SerializeObject(mailBoxes));

            // Act
            var retMailBoxes = dataLoader.Load();

            // Assert
            Assert.IsNotNull(retMailBoxes);
            Assert.AreEqual(listMailBoxes.Count, retMailBoxes?.Count);

        }
    }
}
