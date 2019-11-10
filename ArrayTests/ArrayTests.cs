using Assignment6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayTests
{
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        public void Array_SetGetInBounds_ReturnsCorrectValue()
        {
            // Arrange
            Array<string> arr = new Array<string>(10);

            // Act
            arr.Set(0, "hi");
            bool ret = arr.TryGetValue(0, out string value);

            // Assert
            Assert.AreEqual<string>("hi", value);
            Assert.IsTrue(ret);
        }

        [TestMethod]
        public void Array_SetInBoundsGetOutBounds_ReturnsFalseAndNull()
        {
            // Arrange
            Array<string> arr = new Array<string>(10);

            // Act
            arr.Set(0, "hi");
            bool ret = arr.TryGetValue(20, out string value);

            // Assert
            Assert.IsFalse(ret);
            Assert.IsNull(value);
        }

        [TestMethod]
        public void Array_SetGetOutBounds_ReturnsFalseAndNull()
        {
            // Arrange
            Array<string> arr = new Array<string>(10);

            // Act
            arr.Set(15, "hi");
            bool ret = arr.TryGetValue(15, out string value);

            // Assert
            Assert.IsFalse(ret);
            Assert.IsNull(value);
        }

        [TestMethod]
        public void Array_Contains_ReturnsFalse()
        {
            // Arrange
            Array<string> arr = new Array<string>(10);

            // Act
            arr.Set(5, "hi");
            bool ret = arr.Contains("ho");

            // Assert
            Assert.IsFalse(ret);
        }

        [TestMethod]
        public void Array_Contains_ReturnsTrue()
        {
            // Arrange
            Array<string> arr = new Array<string>(10);

            // Act
            arr.Set(5, "hi");
            bool ret = arr.Contains("hi");

            // Assert
            Assert.IsTrue(ret);
        }

        [TestMethod]
        public void Array_IndexOperatorInBounds_ReturnsCorrectValue()
        {
            // Arrange
            Array<string> arr = new Array<string>(10);

            // Act
            arr[5] = "hi";
            bool ret = arr.Contains("hi");

            // Assert
            Assert.IsTrue(ret);
            Assert.AreEqual<string>("hi", arr[5]);
        }

        [TestMethod]
        public void Array_IndexOperatorOutBounds_ReturnsCorrectValue()
        {
            // Arrange
            Array<string> arr = new Array<string>(10);

            // Act
            arr[15] = "hi";
            bool ret = arr.Contains("hi");

            // Assert
            Assert.IsFalse(ret);
            Assert.AreNotEqual<string>("hi", arr[15]);
        }
    }
}
