using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClaimRepository;
using System;

namespace ClaimTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private ClaimsRepo _repo = new ClaimsRepo();

        [TestInitialize]
        public void Arrange()
        {
            Claims claimFour = new Claims(ClaimType.Theft, 104, "Gun Theft", 1000, new DateTime(2020, 11, 01), new DateTime(2020, 12, 02));
            _repo.AddNewClaim(claimFour);
        }
        [TestMethod]
        public void AddNewClaim_ShouldReturnTrue() 
        {
            Claims claimFive = new Claims(ClaimType.Car, 105, "Totaled Vehicle", 45000, new DateTime(2020, 10, 01), new DateTime(2020, 10, 01));
            int beforeCount = _repo.GetClaimsList().Count;

            _repo.AddNewClaim(claimFive);
            int afterCount = _repo.GetClaimsList().Count;

            Assert.IsTrue(afterCount > beforeCount);
        }
        [TestMethod]
        public void TestingIsValidProperty_ShouldBeFalse()
        {
            Claims claimSix = new Claims(ClaimType.Car, 106, "Totaled Vehicle", 45000, new DateTime(2020, 10, 01), new DateTime(2020, 12, 12));

            Assert.IsFalse(claimSix.IsValid);
        }
    }
}
