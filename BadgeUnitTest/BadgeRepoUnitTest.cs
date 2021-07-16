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
            BadgePOCO badge = new BadgePOCO(61, new System.Collections.Generic.List<string>(5));
            _repo.CreateNewBadge(badge);
        }
        [TestMethod]
        public void Create_IsNull_ReturnTrue()
        {
            BadgePOCO badge = null;
            BadgeRepo repo = new BadgeRepo();

            bool result = repo.CreateNewBadge(badge);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Create_IsNotNull_ReturnFalse()
        {
            BadgePOCO badge = new BadgePOCO(123, new System.Collections.Generic.List<string>(2));
            BadgeRepo repo = new BadgeRepo();

            bool result = repo.CreateNewBadge(badge);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetByID_BadgeExists_ReturnBadge()
        {
            int num = 61;

            BadgePOCO result = _repo.GetBadgeByID(num);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.BadgeID, num);
        }
        [TestMethod]
        public void GetByID_BadgeDoesNotExist_ReturnNull()
        {
            int num = 52;

            BadgePOCO result = _repo.GetBadgeByID(num);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void Update_BadgeExists_ReturnTrue()
        {
            int num = 61;
            BadgePOCO updateBadge = new BadgePOCO(61, new System.Collections.Generic.List<string>(1));

            bool result = _repo.UpdateExistingBadge(num, updateBadge);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Update_BadgeDoesNotExist_ReturnFalse()
        {
            int num = 1234;
            BadgePOCO updateBadge = new BadgePOCO(61, new System.Collections.Generic.List<string>(1));

            bool result = _repo.UpdateExistingBadge(num, updateBadge);

            Assert.IsFalse(result);

        }
    }
}
