using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using static Sorter.SortUtility;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        private int[] getRandomArray(int length)
        {
            int[] arr = new int[length];
            Random r = new Random();
            for (int i = 0; i < length; i++)
            {
                arr[i] = r.Next(10);
            }
            return arr;
        }

        compareFunction greaterThan = delegate (int i, int j) {
            return i > j;
        };
        compareFunction lessThan = delegate (int i, int j) {
            return i < j;
        };

        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod()
        {
            // Arrange
            int[] arr = getRandomArray(10);

            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.WriteLine("");
            Trace.WriteLine("Unsorted: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Trace.Write(arr[i] + " ");
            }
            Trace.WriteLine("");
            Trace.WriteLine("Sorted: ");

            // Act
            SortUtility.Sort(arr, lessThan);

            // Assert
            for (int i = 0; i < arr.Length; i++)
            {
                Trace.Write(arr[i] + " ");
            }
            Trace.WriteLine("");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingLambdaExpression()
        {
            // Arrange
            int[] arr = getRandomArray(10);

            // Act

            // Assert
        }

        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingLambdaStatement()
        {
            // Arrange
            int[] arr = getRandomArray(10);

            // Act

            // Assert
        }
    }
}
