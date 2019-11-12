using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Assignment6
{
    /// <summary>
    /// Extra Credit: cast operator to a C# array or a `System.Collections.Generic.List<T>`
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        public void ArrayString_SetGetInBounds_ReturnsCorrectValue()
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(10);

            // Act
            arr.Add("hi");
            string value = arr[0];

            // Assert
            Assert.AreEqual<string>("hi", value);
        }

        [TestMethod]
        public void ArrayInt_SetGetInBounds_ReturnsCorrectValue()
        {
            // Arrange
            ArrayCollection<int> arr = new ArrayCollection<int>(10);

            // Act
            arr.Add(3);
            int value = arr[0];

            // Assert
            Assert.AreEqual<int>(3, value);
        }

        [TestMethod]
        public void ArrayString_Contains_ReturnsFalse()
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(10);

            // Act
            arr.Add("hi");
            bool ret = arr.Contains("ho");

            // Assert
            Assert.IsFalse(ret);
        }

        [DataTestMethod]
        [DataRow("hi")]
        [DataRow("bye")]
        public void ArrayString_Contains_ReturnsTrue(string s)
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(10);

            // Act
            arr.Add(s);
            bool ret = arr.Contains(s);

            // Assert
            Assert.IsTrue(ret);
        }

        [DataTestMethod]
        [DataRow(0, true)]
        [DataRow(-2, true)]
        [DataRow(-2, false)]
        [DataRow(0, false)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArrayStringInvalidCapacityAndReadOnly_ThrowsException(int capacity, bool isReadOnly)
        {
            // Arrange

            // Act
            if (isReadOnly == true)
            {
                ArrayCollection<string> arr1 = new ArrayCollection<string>(capacity, true);

            } else
            {
                ArrayCollection<string> arr = new ArrayCollection<string>(capacity, false);
            }
            

            // Assert

        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-2)]
        [DataRow(-4)]
        [DataRow(-6)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArrayStringInvalidCapacity_ThrowsException(int capacity)
        {
            // Arrange

            // Act
            ArrayCollection<string> arr1 = new ArrayCollection<string>(capacity);

            // Assert

        }

        [TestMethod]
        public void ArrayString_IndexOperatorInBounds_ReturnsCorrectValue()
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(10);

            // Act
            arr.Add("zero");
            arr.Add("one");
            arr.Add("two");
            arr.Add("three");
            arr.Add("four");
            arr.Add("five");
            bool ret = arr.Contains("five");

            // Assert
            Assert.IsTrue(ret);
            Assert.AreEqual<string>("five", arr[5]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [ExcludeFromCodeCoverage]
        public void ArrayString_IndexOperatorOutBounds_ThrowsException()
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(10);

            // Act
            arr.Add("zero");
            arr.Add("one");
            arr.Add("two");
            arr.Add("three");
            arr.Add("four");
            arr.Add("five");
            string value = arr[15];

            // Assert
        }

        [TestMethod]
        public void ArrayString_Foreach_CorrectValue()
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(10);

            // Act
            arr.Add("zero_");
            arr.Add("one_");
            arr.Add("two_");
            arr.Add("three_");
            arr.Add("four_");
            arr.Add("five_");

            StringBuilder sb = new StringBuilder();
            foreach (string s in arr)
            {
                Assert.IsTrue(s is string);
                sb.Append(s);
            }

            // Assert
            Assert.AreEqual<string>("zero_one_two_three_four_five_", sb.ToString());
        }

        [TestMethod]
        public void ArrayString_AddItems_CountIsCorrect()
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(10);

            // Act
            arr.Add("one");
            arr.Add("two");

            // Assert
            Assert.AreEqual<int>(2, arr.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [ExcludeFromCodeCoverage]
        public void ArrayString_AddNullItem_ThrowsException()
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(10);

            // Act
            arr.Add(null!);
            

            // Assert
            
        }

        [TestMethod]
        public void ArrayString_ClearArray_CountIsZero()
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(10);

            // Act
            arr.Add("hi");
            arr.Clear();

            // Assert
            Assert.AreEqual<int>(0, arr.Count);
        }

        [TestMethod]
        public void ArrayString_RemoveItem_ContentsAreCorrect()
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(10);

            // Act
            arr.Add("hi");
            arr.Add("ho");
            arr.Remove("hi");

            // Assert
            Assert.AreEqual<int>(1, arr.Count);
            Assert.IsFalse(arr.Contains("hi"));
            Assert.IsTrue(arr.Contains("ho"));
        }

        [TestMethod]
        public void ArrayString_SetReadOnlyTrue_RemoveReturnsFalse()
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(10);

            // Act
            arr.Add("hi");
            arr.Add("ho");
            arr.IsReadOnly = true;
            bool ret = arr.Remove("hi");

            // Assert
            Assert.IsFalse(ret);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [ExcludeFromCodeCoverage]
        public void ArrayString_RemoveItemDoesntExist_ThrowsException()
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(10);

            // Act
            bool ret = arr.Remove("hi");

            // Assert
            Assert.IsFalse(ret);
        }

        [TestMethod]
        public void ArrayString_SetReadOnlyTrue_AddDoesntChange()
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(10);

            // Act
            arr.Add("hi");
            arr.Add("ho");
            arr.IsReadOnly = true;
            arr.Add("hum");

            // Assert
            Assert.IsFalse(arr.Contains("hum"));
        }

        [TestMethod]
        public void ArrayString_CopyTo_CorrectContents()
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(10);

            // Act
            arr.Add("hi");
            arr.Add("ho");
            string[] strArr = new string[10];

            arr.CopyTo(strArr, arr.Count);

            StringBuilder sb = new StringBuilder();
            foreach (string s in strArr) 
            {
                sb.Append(s);
            }

            // Assert
            Assert.AreEqual<string>("hiho", sb.ToString());
        }

        [TestMethod]
        public void ArrayString_CreateReadOnlyArray_CannotChange()
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(10, true);

            // Act
            arr.Add("hi");
            arr.Add("ho");
            

            // Assert
            Assert.IsFalse(arr.Contains("hi"));
            Assert.IsFalse(arr.Contains("ho"));
            Assert.AreEqual<int>(0, arr.Count);
        }

        [TestMethod]
        public void ArrayString_GetEnumerator_CorrectValues()
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(10);

            // Act
            arr.Add("hi");
            arr.Add("ho");
            IEnumerator<string> e = arr.GetEnumerator();
            
            StringBuilder sb = new StringBuilder();

            while (e.MoveNext())
            {
                sb.Append(e.Current);
            }

            // Assert
            Assert.AreEqual<string>("hiho", sb.ToString());
        }

        [TestMethod]
        public void ArrayString_SetItemValid_ReturnsCorrectValue()
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(10);

            // Act
            arr.Add("hi");
            arr.Add("ho");
            arr[0] = "ho";

            // Assert
            Assert.AreEqual<string>("ho", arr[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [ExcludeFromCodeCoverage]
        public void ArrayString_SetItemInvalid_ThrowsException()
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(10);

            // Act
            arr.Add("hi");
            arr.Add("ho");
            arr[0] = null!;

            // Assert
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [ExcludeFromCodeCoverage]
        public void ArrayInt_SetItemInvalid_ThrowsException()
        {
            // Arrange
            ArrayCollection<int> arr = new ArrayCollection<int>(10);

            // Act
            arr[-5] = 5;

            // Assert

        }

        [DataTestMethod]
        [DataRow(new string[] { "one", "two", "three"})]
        [DataRow(new string[] { "", "two", "" })]
        public void ArrayString_CollectionInitializer_CorrectContents(string[] strArr)
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(strArr);

            // Act
            string s = arr[1];

            // Assert
            Assert.AreEqual<string>("two", s);
            Assert.AreEqual(3, arr.Count);
        }

        [DataTestMethod]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentNullException))]
        [ExcludeFromCodeCoverage]
        public void ArrayString_CollectionInitializerNull_ThrowsException(string[] strArr)
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(strArr);

            // Act

            // Assert
            Assert.AreEqual(0, arr.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [ExcludeFromCodeCoverage]
        public void ArrayInt_AddingTooManyItems_ThrowsException()
        {
            // Arrange
            ArrayCollection<int> arr = new ArrayCollection<int>(3);

            // Act
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            arr.Add(4);

            // Assert

        }

        [TestMethod]
        public void ArrayInt_AddingToCapacity_ReturnsCorrectValue()
        {
            // Arrange
            ArrayCollection<int> arr = new ArrayCollection<int>(3);

            // Act
            arr.Add(10);
            arr.Add(20);
            arr.Add(30);

            // Assert
            Assert.AreEqual<int>(30, arr[2]);
        }

        /// <summary>
        /// Extra Credit
        /// 
        /// </summary>
        [TestMethod]
        public void ArrayString_CastArray_CorrectValues()
        {
            // Arrange
            ArrayCollection<string> arr = new ArrayCollection<string>(10);
            arr.Add("hi");
            arr.Add("ho");

            // Act
            string[] strArr = (string[])arr;

            // Assert
            Assert.AreEqual<string>("hi", strArr[0]);
            Assert.AreEqual<string>("ho", strArr[1]);
        }

        /// <summary>
        /// Extra Credit
        /// 
        /// </summary>
        [TestMethod]
        public void ArrayString_CastArrayCollection_CorrectValues()
        {
            // Arrange
            string[] strArr = new string[] { "hi", "ho" };

            // Act
            ArrayCollection<string> arr = (ArrayCollection<string>)strArr;

            // Assert
            Assert.AreEqual<string>("hi", arr[0]);
            Assert.AreEqual<string>("ho", arr[1]);
        }

        /// <summary>
        /// Extra Credit
        /// 
        /// </summary>
        [TestMethod]
        public void ArrayInt_CastArray_CorrectValues()
        {
            // Arrange
            ArrayCollection<int> arr = new ArrayCollection<int>(10);
            arr.Add(4);
            arr.Add(5);

            // Act
            int[] intArr = (int[])arr;

            // Assert
            Assert.AreEqual<int>(4, intArr[0]);
            Assert.AreEqual<int>(5, intArr[1]);
        }

        /// <summary>
        /// Extra Credit
        /// 
        /// </summary>
        [TestMethod]
        public void ArrayInt_CastArrayCollection_CorrectValues()
        {
            // Arrange
            int[] intArr = new int[] { 8, 9 };

            // Act
            ArrayCollection<int> arr = (ArrayCollection<int>)intArr;

            // Assert
            Assert.AreEqual<int>(8, arr[0]);
            Assert.AreEqual<int>(9, arr[1]);
        }
    }
}
