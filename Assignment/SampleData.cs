using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData, IDisposable
    {
        public SampleData(Stream? source)
        {
            Source = source;
        }

        public SampleData() : this(null) { }

        public Stream? Source { get; private set; }

        public enum Column
        {
            Id, FirstName, LastName, Email, StreetAddress, City, State, Zip
        };

        // 1.
        public IEnumerable<string> CsvRows
        {
            get
            {
                if (Source is null)
                {
                    return File.ReadAllLines("People.csv").Skip(1);
                }
                else
                {
                    Source.Position = 0;
                    using StreamReader reader = new StreamReader(Source, leaveOpen: true);
                    string? line = reader.ReadLine();
                    List<string> rows = new List<string>();
                    while (line != null)
                    {
                        rows.Add(line);
                        line = reader.ReadLine();
                    }
                    reader.Dispose();

                    return rows.Skip(1);
                }

            }
        }

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
        public IEnumerable<IPerson> People {
            get
            {
                IEnumerable<Person> ret = CsvRows.Select<string, Person>(i =>
                {
                    string[] arr = i.Split(",");
                    Person p = new Person(
                        arr[(int)Column.FirstName],
                        arr[(int)Column.LastName],
                        new Address(
                            arr[(int)Column.StreetAddress],
                            arr[(int)Column.City],
                            arr[(int)Column.State],
                            arr[(int)Column.Zip]
                            ),
                        arr[(int)Column.Email]
                    );
                    return p;
                });
                return ret
                        .OrderBy(i => i.Address.State)
                        .ThenBy(i => i.Address.City)
                        .ThenBy(i => i.Address.Zip)
                ;
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) =>
                from person in People
                where filter(person.EmailAddress)
                select (person.FirstName, person.LastName);

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {
            IEnumerable<string> states =
               from person in people
               select person.Address.State;

            return states.Distinct<string>()
                .Aggregate((i, j) => i + "," + j);
        }



        #region IDisposable Support
#pragma warning disable INTL0001 // Fields _PascalCase
        private bool disposedValue = false; // To detect redundant calls
#pragma warning restore INTL0001 // Fields _PascalCase

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    Source?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }


        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SampleData()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
        public void Dispose()
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
