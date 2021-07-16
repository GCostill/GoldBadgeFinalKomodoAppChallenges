using MealClass.POCO;
using MealClass.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MealUnitTest
{
    [TestClass]
    public class MealClassRepoTests
    {
        [TestInitialize]

        [TestMethod]
        public void Add_ItemIsNull_ReturnFalse()
        {
            //Arrange
            MenuItemPOCO item = null;
            MenuItemRepo repo = new MenuItemRepo();

            //Act
            bool result = repo.AddMenuItemToList(item);

            //Assert
            Assert.IsFalse(result);

        }
        [TestMethod]
        public void Add_ItemIsNotNull_ReturnTrue()
        {
            MenuItemPOCO item = new MenuItemPOCO(5, "Berry Blitz", "Triple Berry Blend", 2.30m, "Blueberries, Strawberries, Raspberries");
            MenuItemRepo repo = new MenuItemRepo();

            bool result = repo.AddMenuItemToList(item);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetByNum_MealExists_ReturnItem()
        {
            MenuItemPOCO item = new MenuItemPOCO(3, "Salami Sammich", "A comforting lunch", 3.00m, "Salami, Bread, Comfort");
            MenuItemRepo repo = new MenuItemRepo();
            repo.AddMenuItemToList(item);
            int num = 3;

            MenuItemPOCO result = repo.GetItemByNum(num);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.MealNumber, num);
        }
        [TestMethod]
        public void GetByNum_MealDoesNotExist_ReturnNull()
        {
            MenuItemPOCO item = new MenuItemPOCO(3, "Salami Sammich", "A comforting lunch", 3.00m, "Salami, Bread, Comfort");
            MenuItemRepo repo = new MenuItemRepo();
            repo.AddMenuItemToList(item);
            int num = 5;

            MenuItemPOCO result = repo.GetItemByNum(num);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void DeleteMeal_MealIsNull_ReturnFalse()
        {

        }
        [TestMethod]
        public void DeleteMeal_MealIsNotNull_DeleteItem()
        {

        }
    }
}
