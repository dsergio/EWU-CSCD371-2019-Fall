using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance.Tests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void Food_Upc_IsSet()
        {
            // Arrange
            Food food = new Food();

            // Act
            food.Upc = "123";
            food.PrintInfo();

            // Assert
            Assert.AreEqual("123", food.Upc);
        }

        [TestMethod]
        public void Food_Brand_IsSet()
        {
            // Arrange
            Food food = new Food();

            // Act
            food.Brand = "safeway";
            food.PrintInfo();

            // Assert
            Assert.AreEqual("safeway", food.Brand);
        }

        [TestMethod]
        public void Television_Manufacturer_IsSet()
        {
            // Arrange
            Television television = new Television();

            // Act
            television.Manufacturer = "sony";
            television.PrintInfo();

            // Assert
            Assert.AreEqual("sony", television.Manufacturer);
        }

        [TestMethod]
        public void Television_Size_IsSet()
        {
            // Arrange
            Television television = new Television();

            // Act
            television.Size = "50 inch";
            television.PrintInfo();

            // Assert
            Assert.AreEqual("50 inch", television.Size);
        }
    }
}
