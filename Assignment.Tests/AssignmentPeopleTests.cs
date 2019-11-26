﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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
        public void GetUniqueSortedListOfStatesGivenCsvRows_UsingHardCodedEmptyList_CorrectCount()
        {
            // Arrange
            MemoryStream memoryStream = new MemoryStream();

            using var writer = new StreamWriter(memoryStream, leaveOpen: true);
            writer.WriteLine("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip");
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
            Assert.AreEqual(0, data.Count());


            // Clean up
            sampleData.Dispose();

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [ExcludeFromCodeCoverage]
        public void GetUniqueSortedListOfStatesGivenCsvRows_InvalidHardCodedList_ThrowsException()
        {
            // Arrange
            MemoryStream memoryStream = new MemoryStream();

            using var writer = new StreamWriter(memoryStream, leaveOpen: true);
            writer.WriteLine("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip");
            writer.WriteLine("8,Joly,Scneider,");
            writer.WriteLine(",1 Rutledge Point,Spokane,WA,99021");
            writer.WriteLine("20,Chelsy");
            writer.Flush();
            writer.Dispose();

            SampleData sampleData = new SampleData(memoryStream);

            // Act
            IEnumerable<string> data = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            // Clean up
            sampleData.Dispose();

            foreach (string s in data)
            {
                Console.WriteLine(s);
            }

            // Assert

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

        [TestMethod]
        public void PeopleProperty_UsingPeoplecsv_IsSorted()
        {

            // Arrange
            SampleData sampleData = new SampleData();

            // Act
            IEnumerable<IPerson> ppl = sampleData.People;

            // Assert
            IPerson[] arr = ppl.ToArray();
            for (int i = 0; i < ppl.Count() - 1; i++)
            {
                Console.WriteLine(arr[i].ToString());

                int compareState = string.Compare(
                    arr[i].Address.State,
                    arr[i + 1].Address.State,
                    System.StringComparison.CurrentCultureIgnoreCase
                    );
                int compareCity = string.Compare(
                    arr[i].Address.City,
                    arr[i + 1].Address.City,
                    System.StringComparison.CurrentCultureIgnoreCase
                    );
                int compareZip = string.Compare(
                    arr[i].Address.Zip,
                    arr[i + 1].Address.Zip,
                    System.StringComparison.CurrentCultureIgnoreCase
                    );

                Assert.IsTrue(compareState <= 0);
                if (compareState == 0)
                {
                    Assert.IsTrue(compareCity <= 0);
                    if (compareCity == 0)
                    {
                        Assert.IsTrue(compareZip <= 0);
                    }
                }
            }

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
            foreach ((string firstName, string lastName) in ppl)
            {
                Console.WriteLine(firstName + " " + lastName);
                Assert.AreEqual<string>(first, firstName);
                Assert.AreEqual<string>(last, lastName);
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

        [DataTestMethod]
        [DataRow("street")]
        [DataRow("city")]
        [DataRow("state")]
        [DataRow("zip")]
        [ExpectedException(typeof(ArgumentNullException))]
        [ExcludeFromCodeCoverage]
        public void Address_CreateAddressInvalid_ThrowsException(string type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            // Arrange

            // Act
            _ = new Address(
                type == "street" ? null! : "street",
                type == "city" ? null! : "city",
                type == "state" ? null! : "state",
                type == "zip" ? null! : "zip"
                );

            // Assert
        }

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