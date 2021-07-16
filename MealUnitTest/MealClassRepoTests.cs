using MealClass.POCO;
using MealClass.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MealUnitTest
{
    [TestClass]
    public class MealClassRepoTests
    {
        private readonly MenuItemRepo _repo = new MenuItemRepo();
        [TestInitialize]
        public void Arrange()
        {
            MenuItemPOCO item = new MenuItemPOCO(3, "Salami Sammich", "A comforting lunch", 3.00m, "Salami, Bread, Comfort");
            _repo.AddMenuItemToList(item);
        }

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
            int num = 3;

            MenuItemPOCO result = _repo.GetItemByNum(num);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.MealNumber, num);
        }
        [TestMethod]
        public void GetByNum_MealDoesNotExist_ReturnNull()
        {
            int num = 5;

            MenuItemPOCO result = _repo.GetItemByNum(num);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void DeleteMeal_MealIsNull_ReturnFalse()
        {
            int num = 1234;

            bool result = _repo.DeleteMenuItem(num);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void DeleteMeal_MealIsNotNull_ReturnTrue()
        {
            int num = 3;

            bool result = _repo.DeleteMenuItem(num);

            Assert.IsTrue(result);
        }
    }
}
