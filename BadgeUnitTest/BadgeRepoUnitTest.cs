using BadgeClass.POCO;
using BadgeClass.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BadgeUnitTest
{
    [TestClass]
    public class BadgeRepoUnitTest
    {
        private readonly BadgeRepo _repo = new BadgeRepo();

        [TestInitialize]
        public void Arrange()
        {
            Badge badge = new Badge(new System.Collections.Generic.List<string>{"A1","B4"});
            _repo.CreateNewBadge(badge);
        }
        [TestMethod]
        public void Create_IsNull_ReturnTrue()
        {
            Badge badge = null;
            BadgeRepo repo = new BadgeRepo();

            bool result = repo.CreateNewBadge(badge);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Create_IsNotNull_ReturnFalse()
        {
            Badge badge = new Badge(new System.Collections.Generic.List<string> { "A1", "B4" });
            BadgeRepo repo = new BadgeRepo();

            bool result = repo.CreateNewBadge(badge);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetByID_BadgeExists_ReturnBadge()
        {
            int num = 1;

            Badge result = _repo.GetBadgeByID(num);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.BadgeID, num);
        }
        [TestMethod]
        public void GetByID_BadgeDoesNotExist_ReturnNull()
        {
            int num = 209;

            Badge result = _repo.GetBadgeByID(num);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void Update_BadgeExists_ReturnTrue()
        {
            int num = 1;
            Badge updateBadge = new Badge(new System.Collections.Generic.List<string> { "A2", "B4" });

            bool result = _repo.UpdateExistingBadge(num, updateBadge);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Update_BadgeDoesNotExist_ReturnFalse()
        {
            int num = 1234;
            Badge updateBadge = new Badge(new System.Collections.Generic.List<string> { "A2", "B4" });

            bool result = _repo.UpdateExistingBadge(num, updateBadge);

            Assert.IsFalse(result);

        }
    }
}
