using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass]
    public class ShoppingItemVisibleConverterTests
    {
        [TestMethod]
        public void ShoppingItemVisibleConverter_ShoppingItem_ReturnsVisible()
        {
            // Arrange
            ShoppingItemVisibleConverter shoppingItemVisibleConverter = new ShoppingItemVisibleConverter();
            ShoppingItem shoppingItem = new ShoppingItem("name", 32, 1, ShoppingItem.UnitType.Each);

            // Act
            string str = (string)shoppingItemVisibleConverter.Convert(shoppingItem);

            // Assert
            Assert.AreEqual("Visible", str);
        }

        [TestMethod]
        public void ShoppingItemVisibleConverter_String_ReturnsHidden()
        {
            // Arrange
            ShoppingItemVisibleConverter shoppingItemVisibleConverter = new ShoppingItemVisibleConverter();
            string someString = "some string";

            // Act
            string str = (string)shoppingItemVisibleConverter.Convert(someString);

            // Assert
            Assert.AreEqual("Hidden", str);
        }
    }
}
