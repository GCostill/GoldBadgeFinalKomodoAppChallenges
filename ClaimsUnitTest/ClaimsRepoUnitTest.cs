using ClaimsClass.POCO;
using ClaimsClass.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClaimsUnitTest
{
    [TestClass]
    public class ClaimsRepoUnitTest
    {
        [TestMethod]
        public void Create_ClaimIsNull_ReturnFalse()
        {
            ClaimsPOCO claim = null;
            ClaimsRepo repo = new ClaimsRepo();

            bool result = repo.CreateNewClaim(claim);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Create_ClaimIsNotNull_ReturnTrue()
        {
            ClaimsPOCO claim = new ClaimsPOCO("5", ClaimType.car, "car accident", 1000, new DateTime (07/15/2021) ,DateTime.Today, true);
            ClaimsRepo repo = new ClaimsRepo();

            bool result = repo.CreateNewClaim(claim);

            Assert.IsTrue(result);
        }
    }
}
