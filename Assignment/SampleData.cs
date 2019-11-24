using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        public enum Column
        {
            Id, FirstName, LastName, Email, StreetAddress, City, State, Zip
        };

        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines("People.csv").Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            IEnumerable<string> ret =
                from row in CsvRows
                let state = row.Split(",")[(int)Column.State]
                orderby state
                select state;

            return ret.Distinct<string>();
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            return GetUniqueSortedListOfStatesGivenCsvRows().Aggregate<string>((i, j) => i + "," + j);
        }

        // 4.
        public IEnumerable<IPerson> People => CsvRows.Select<string, Person>(i => {
            string[] arr = i.Split(",");
            Person p = new Person()
            {
                FirstName = arr[(int) Column.FirstName],
                LastName = arr[(int) Column.LastName],
                Address = new Address()
                {
                    StreetAddress = arr[(int) Column.StreetAddress],
                    City = arr[(int) Column.City],
                    State = arr[(int)Column.State],
                    Zip = arr[(int)Column.Zip],
                },
                EmailAddress = arr[(int) Column.Email]
            };
            return p;
        });

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            var ret =
                from person in People
                where filter(person.EmailAddress)
                select (person.FirstName, person.LastName);
            return ret;
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {
            IEnumerable<string> ppl =
               from person in people
               select person.Address.State;

            string s = ppl.Distinct<string>().Aggregate((i, j) => i + "," + j);

            return s;
        }
    }
}
