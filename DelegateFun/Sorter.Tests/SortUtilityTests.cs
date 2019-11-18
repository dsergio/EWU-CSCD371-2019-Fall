using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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

        private readonly compareFunction _GreaterThan = delegate (int i, int j)
        {
            return i > j;
        };
        private readonly compareFunction _LessThan = delegate (int i, int j) {
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
            SortUtility.Sort(arr, _LessThan);

            // Assert
            Trace.WriteLine("Sorted: ");
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Trace.Write(arr[i] + " ");
                Assert.IsTrue(arr[i] <= arr[i + 1]);
            }
            Trace.WriteLine(arr[arr.Length - 1]);
        }

        [TestMethod]
        public void SortUtility_ShouldSortDescending_UsingAnAnonymousMethod()
        {
            // Arrange
            int[] arr = getRandomArray(10);
            TraceOutput(arr);

            // Act
            SortUtility.Sort(arr, _GreaterThan);

            // Assert
            Trace.WriteLine("Sorted: ");
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Trace.Write(arr[i] + " ");
                Assert.IsTrue(arr[i] >= arr[i + 1]);
            }
            Trace.WriteLine(arr[arr.Length - 1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [ExcludeFromCodeCoverage]
        public void SortUtility_NullArraySortAscending_UsingAnAnonymousMethod()
        {
            // Arrange

            // Act
            SortUtility.Sort(null!, _LessThan);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [ExcludeFromCodeCoverage]
        public void SortUtility_ArraySort_NullDelegate()
        {
            // Arrange
            int[] arr = getRandomArray(10);
            TraceOutput(arr);

            // Act
            SortUtility.Sort(arr, null!);

            // Assert
        }

        [TestMethod]
        public void SortUtility_ShouldSortDescending_UsingLambdaExpression()
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
            Trace.WriteLine(arr[arr.Length - 1]);
        }

        [TestMethod]
        public void SortUtility_ShouldSortBase2Ascending_UsingLambdaStatement()
        {
            // Arrange
            int[] arr = getRandomArray(10);
            TraceOutput(arr);

            // Act
            SortUtility.Sort(arr, (i, j) =>
            {
                int x = i % 2;
                int y = j % 2;
                return x < y;
            });

            // Assert
            Trace.WriteLine("Sorted: ");
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Trace.Write(arr[i] + " ");
                Assert.IsTrue(arr[i] % 2 <= arr[i + 1] % 2);
            }
            Trace.WriteLine(arr[arr.Length - 1]);
            //Assert.IsTrue(true);
        }
    }
}
