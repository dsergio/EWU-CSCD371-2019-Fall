using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void MainWindowViewModel_AddItemCommand_ReturnsCorrectCount()
        {
            // Arrange
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            mainWindowViewModel.SelectedShoppingItem = new ShoppingItem("name", 1, 2, ShoppingItem.UnitType.Each);

            // Act
            mainWindowViewModel.AddItemCommand.Execute(true);

            // Assert
            Assert.AreEqual(4, mainWindowViewModel.ShoppingItemList.Count);
        }

        [TestMethod]
        public void MainWindowViewModel_CreateItemCommand_ReturnsCorrectCount()
        {
            // Arrange
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            

            // Act
            mainWindowViewModel.CreateNewItemCommand.Execute(true);

            // Assert
            Assert.AreEqual(1, mainWindowViewModel.SelectedShoppingItem.Quantity);
        }

        [TestMethod]
        public void MainWindowViewModel_AddNullCommand_ReturnsCorrectCount()
        {
            // Arrange
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            mainWindowViewModel.SelectedShoppingItem = null!;

            // Act
            mainWindowViewModel.AddItemCommand.Execute(true);

            // Assert
            Assert.AreEqual(3, mainWindowViewModel.ShoppingItemList.Count);
        }

        [TestMethod]
        public void MainWindowViewModel_RemoveItemCommand_ReturnsCorrectCount()
        {
            // Arrange
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            mainWindowViewModel.SelectedShoppingItem = mainWindowViewModel.ShoppingItemList.First();

            // Act
            mainWindowViewModel.DeleteItemCommand.Execute(true);

            // Assert
            Assert.AreEqual(2, mainWindowViewModel.ShoppingItemList.Count);
        }

        [TestMethod]
        public void MainWindowViewModel_RemoveNullCommand_ReturnsCorrectCount()
        {
            // Arrange
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            mainWindowViewModel.SelectedShoppingItem = null!;

            // Act
            mainWindowViewModel.DeleteItemCommand.Execute(true);

            // Assert
            Assert.AreEqual(3, mainWindowViewModel.ShoppingItemList.Count);
        }
    }
}
