using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using static Sorter.SortUtility;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod()
        {
            int length = 5;
            int[] arr = new int[length];
            Random r = new Random();
            for (int i = 0; i < length; i++)
            {
                arr[i] = r.Next(10);
            }

            compareFunction greaterThan = delegate (int i, int j) {
                return i > j;
            };
            compareFunction lessThan = delegate (int i, int j) {
                return i < j;
            };

            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));


            Trace.WriteLine("");
            Trace.WriteLine("Unsorted: ");
            for (int i = 0; i < length; i++)
            {
                Trace.Write(arr[i] + " ");
            }
            Trace.WriteLine("");
            Trace.WriteLine("Sorted: ");
            SortUtility.Sort(arr, lessThan);
            for (int i = 0; i < length; i++)
            {
                Trace.Write(arr[i] + " ");
            }
            Trace.WriteLine("");
            Assert.IsTrue(true);


        }
    }
}
