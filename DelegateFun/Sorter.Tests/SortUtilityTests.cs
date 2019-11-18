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

        private void TraceOutput(int[] arr)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.WriteLine("");
            Trace.WriteLine("Unsorted: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Trace.Write(arr[i] + " ");
            }
            Trace.WriteLine("");
        }

        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod()
        {
            // Arrange
            int[] arr = getRandomArray(10);
            TraceOutput(arr);

            // Act
            SortUtility.Sort(arr, lessThan);

            // Assert
            Trace.WriteLine("Sorted: ");
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Trace.Write(arr[i] + " ");
                Assert.IsTrue(arr[i] <= arr[i + 1]);
            }
        }

        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingLambdaExpression()
        {
            // Arrange
            int[] arr = getRandomArray(10);
            TraceOutput(arr);

            // Act
            SortUtility.Sort(arr, (i, j) => i > j);

            // Assert
            Trace.WriteLine("Sorted: ");
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Trace.Write(arr[i] + " ");
                Assert.IsTrue(arr[i] >= arr[i + 1]);
            }
        }

        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingLambdaStatement()
        {
            // Arrange
            int[] arr = getRandomArray(10);
            TraceOutput(arr);

            // Act
            SortUtility.Sort(arr, (i, j) =>
            {
                return i < j;
            });

            // Assert
            Trace.WriteLine("Sorted: ");
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Trace.Write(arr[i] + " ");
                Assert.IsTrue(arr[i] <= arr[i + 1]);
            }
        }
    }
}
