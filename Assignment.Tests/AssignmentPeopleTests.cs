using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Assignment.Tests
{
    [TestClass]
    public class AssignmentPeopleTests
    {
        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_UsingHardCodedList_CorrectCount()
        {
            // Arrange
            MemoryStream memoryStream = new MemoryStream();

            using var writer = new StreamWriter(memoryStream, leaveOpen: true);
            writer.WriteLine("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip");
            writer.WriteLine("8,Joly,Scneider,jscneider7@pagesperso-orange.fr,53 Grim Point,Spokane,WA,99022");
            writer.WriteLine("15,Phillida,Chastagnier,pchastagniere@reference.com,1 Rutledge Point,Spokane,WA,99021");
            writer.WriteLine("20,Chelsy,Buckle,cbucklej@tiny.cc,38 Talisman Hill,Jacksonville,FL,57619");
            writer.Flush();
            writer.Dispose();

            SampleData sampleData = new SampleData(memoryStream);


            // Act
            IEnumerable<string> data = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            foreach (string s in data)
            {
                Console.WriteLine(s);
            }


            // Assert
            Assert.AreEqual(2, data.Count());


            // Clean up
            sampleData.Dispose();

        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_UsingLinq_CorrectCount()
        {
            // Arrange
            SampleData sampleData = new SampleData();

            IEnumerable<string> d = File.ReadAllLines("People.csv")
                .Skip(1)
                .Select(i => i.Split(",")[(int)SampleData.Column.State])
                .OrderBy(i => i)
                .Distinct()
                ;

            // Act
            IEnumerable<string> data = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            foreach (string s in d)
            {
                Console.WriteLine(s);
            }

            // Assert
            Assert.AreEqual(d.Count(), data.Count());

            // Clean up
            sampleData.Dispose();

        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_UsingHardcodedData_ReturnsCorrectValue()
        {
            // Arrange
            MemoryStream memoryStream = new MemoryStream();

            using var writer = new StreamWriter(memoryStream, leaveOpen: true);
            writer.WriteLine("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip");
            writer.WriteLine("8,Joly,Scneider,jscneider7@pagesperso-orange.fr,53 Grim Point,Spokane,WA,99022");
            writer.WriteLine("15,Phillida,Chastagnier,pchastagniere@reference.com,1 Rutledge Point,Spokane,WA,99021");
            writer.WriteLine("20,Chelsy,Buckle,cbucklej@tiny.cc,38 Talisman Hill,Jacksonville,FL,57619");
            writer.WriteLine("11,Henri,Dorr,hdorra@exblog.jp,2646 Hazelcrest Road,San Francisco,CA,40486");
            writer.WriteLine("25,Jedd,Boissier,jboissiero@cbsnews.com,1 Arrowood Crossing,San Diego,CA,96101");
            writer.Flush();
            writer.Dispose();

            SampleData sampleData = new SampleData(memoryStream);

            // Act
            string data = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

            Console.WriteLine(data);

            // Assert
            Assert.AreEqual("CA,FL,WA", data);

            // Clean up
            sampleData.Dispose();
        }

        [DataTestMethod]
        [DataRow("16,Ewart,Puckinghorne,epuckinghornef@indiatimes.com,9 Forster Lane,Lincoln,NE,40053")]
        [DataRow("8,Joly,Scneider,jscneider7@pagesperso-orange.fr,53 Grim Point,Spokane,WA,99022")]
        public void PeopleProperty_UsingHardcodedCsvPeople_ReturnsCorrectValue(string dataRow)
        {
            if (dataRow is null)
            {
                throw new ArgumentNullException(nameof(dataRow));
            }

            // Arrange
            MemoryStream memoryStream = new MemoryStream();

            using var writer = new StreamWriter(memoryStream, leaveOpen: true);
            writer.WriteLine("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip");
            writer.WriteLine(dataRow);
            writer.Flush();
            writer.Dispose();

            SampleData sampleData = new SampleData(memoryStream);

            // Act
            IEnumerable<IPerson> ppl = sampleData.People;

            string[] arr = dataRow.Split(",");

            // Assert
            Assert.AreEqual(1, ppl.Count());
            Assert.AreEqual(ppl.ToArray()[0].FirstName, arr[(int)SampleData.Column.FirstName]);
            Assert.AreEqual(ppl.ToArray()[0].LastName, arr[(int)SampleData.Column.LastName]);
            Assert.AreEqual(ppl.ToArray()[0].EmailAddress, arr[(int)SampleData.Column.Email]);
            Assert.AreEqual(ppl.ToArray()[0].Address.StreetAddress, arr[(int)SampleData.Column.StreetAddress]);
            Assert.AreEqual(ppl.ToArray()[0].Address.City, arr[(int)SampleData.Column.City]);
            Assert.AreEqual(ppl.ToArray()[0].Address.State, arr[(int)SampleData.Column.State]);
            Assert.AreEqual(ppl.ToArray()[0].Address.Zip, arr[(int)SampleData.Column.Zip]);

            // Clean up
            sampleData.Dispose();
        }

        [DataTestMethod]
        [DataRow("sdennington9@chron.com", "Scarface", "Dennington")]
        [DataRow("ibester6@psu.edu", "Issiah", "Bester")]
        [DataRow("cleathe1d@columbia.edu", "Claudell", "Leathe")]
        public void PeopleCsv_FilterByEmailAddress_NameMatchesEmailRecord(string email, string first, string last)
        {
            if (email is null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (first is null)
            {
                throw new ArgumentNullException(nameof(first));
            }

            if (last is null)
            {
                throw new ArgumentNullException(nameof(last));
            }

            // Arrange
            SampleData sampleData = new SampleData();

            // Act
            IEnumerable<(string, string)> ppl = sampleData.FilterByEmailAddress(i => i == email);

            // Assert
            foreach ((string firstName, string lastName) i in ppl)
            {
                Console.WriteLine(i.firstName + " " + i.lastName);
                Assert.AreEqual<string>(first, i.firstName);
                Assert.AreEqual<string>(last, i.lastName);
            }

            // Clean up
            sampleData.Dispose();

        }

        [DataTestMethod]
        [DataRow("WA")]
        [DataRow("OR")]
        public void PeopleProperty_GetAggregateListOfStatesGivenPeopleCollection_ReturnsCorrectValue(string state)
        {
            if (state is null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            // Arrange
            SampleData sampleData = new SampleData();

            IEnumerable<IPerson> ppl =
                from person in sampleData.People
                where person.Address.State == state
                select person;


            // Act
            string s = sampleData.GetAggregateListOfStatesGivenPeopleCollection(ppl);
            Console.WriteLine(s);

            // Assert
            Assert.AreEqual(state, s);

            // Clean up
            sampleData.Dispose();

        }
    }
}
