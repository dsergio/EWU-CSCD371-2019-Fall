using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment.Tests
{
    [TestClass]
    public class AssignmentPeopleTests
    {
        [TestMethod]
        public void PeopleCsv_Stub_Stub()
        {
            // Arrange
            ISampleData sampleData = new SampleData();

            // Act
            IEnumerable<string> data = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            foreach (string s in data)
            {
                Console.WriteLine(s);
            }

            // Assert

        }

        [TestMethod]
        public void PeopleCsv_Stub2_Stub()
        {
            // Arrange
            ISampleData sampleData = new SampleData();

            // Act
            string data = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

            Console.WriteLine(data);

            // Assert
        }

        [TestMethod]
        public void PeopleCsv_Stub3_Stub()
        {
            // Arrange
            ISampleData sampleData = new SampleData();

            // Act
            IEnumerable<IPerson> ppl = sampleData.People;

            foreach (Person p in ppl)
            {
                Console.WriteLine(p.FirstName + " " + p.LastName + " " + p.Address.City);
            }
            // Assert
        }

        [DataTestMethod]
        [DataRow("sdennington9@chron.com", "Scarface", "Dennington")]
        public void PeopleCsv_Stub4_Stub(string email, string first, string last)
        {
            // Arrange
            ISampleData sampleData = new SampleData();

            // Act
            IEnumerable<(string, string)> ppl = sampleData.FilterByEmailAddress(i => i == email);

            // Assert
            foreach ((string, string) i in ppl)
            {
                Console.WriteLine(i.Item1 + " " + i.Item2);
                Assert.AreEqual<string>(first, i.Item1);
                Assert.AreEqual<string>(last, i.Item2);
            }

        }

        [TestMethod]
        public void PeopleCsv_Stub5_Stub()
        {
            // Arrange
            ISampleData sampleData = new SampleData();

            var ppl =
                from person in sampleData.People
                where person.Address.State == "WA"
                select person;
            

            //IEnumerable<IPerson> ppl = sampleData.People.Select<IPerson, IPerson>(i => i.Address.State == "WA");

            // Act
            string s = sampleData.GetAggregateListOfStatesGivenPeopleCollection(ppl);
            Console.WriteLine(s);

            // Assert

        }
    }
}
