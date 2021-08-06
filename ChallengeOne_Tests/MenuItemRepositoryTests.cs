using ChallengeOne_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeOne_Tests
{
    [TestClass]
    public class MenuItemRepositoryTests
    {
        private MenuItemRepository _repo;
        private MenuItem _item;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuItemRepository();
            List<string> ingredients = new List<string>();
            string ingredient = "2 breads";
            string secondIngredient = "cheese";
            string thirdIngredient = "ham";
            string fourthIngredient = "lettuce";
            ingredients.Add(ingredient);
            ingredients.Add(secondIngredient);
            ingredients.Add(thirdIngredient);
            ingredients.Add(fourthIngredient);
            _item = new MenuItem(1, "Sandwich", "basic sandwich", ingredients, 1.99m);

            _repo.AddItemToList(_item);
        }
        // Add Method
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            //Arrange
            MenuItem item = new MenuItem();
            item.Number = 1;
            MenuItemRepository repository = new MenuItemRepository();

            //Act
            repository.AddItemToList(item);
            MenuItem itemFromMenu = repository.GetMenuItemByNumber(1);

            //Assert
            Assert.IsNotNull(itemFromMenu);
        }
        // Read Method
        [TestMethod]
        public void GetItemList_ShouldGetNotNull()
        {
            //Arrange
            //TestInitialize

            //Act
            List<MenuItem> items = _repo.GetItemList();

            //Assert
            Assert.IsNotNull(items);
        }
        // Delete Method
        [TestMethod]
        public void DeleteItem_ShouldReturnTrue()
        {
            //Arrange
            //TestInitialize

            //Act
            bool deletedResult = _repo.RemoveItemFromList(_item.Number);

            //Assert
            Assert.IsTrue(deletedResult);
        }
        //Helper Method
        [TestMethod]
        public void GetMenuItemByNumber_ShouldGetNotNull()
        {
            //Arrange
            //TestInitialize

            //Act
            MenuItem item = _repo.GetMenuItemByNumber(1);

            //Assert
            Assert.IsNotNull(item);
        }

    }
}
