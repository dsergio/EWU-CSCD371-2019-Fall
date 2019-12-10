using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass]
    public class ShoppingListTests
    {
        [TestMethod]
        public void ShoppingList_Stub_Stub()
        {
            // Arrange
            ShoppingItem shoppingItem = new ShoppingItem("item 1", 1, 3.2, ShoppingItem.UnitType.Each);

            // Act

            // Assert
            Assert.AreEqual("item 1", shoppingItem.Name);

        }
    }
}
