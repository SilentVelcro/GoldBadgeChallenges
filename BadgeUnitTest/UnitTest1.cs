using BadgeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BadgeUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Badge_Repo _repo = new Badge_Repo();

        [TestInitialize]
        public void Arrange()
        {
            Badge badge = new Badge(4, new List<string>() { "A2", "A7" });
            Badge badgeOne = new Badge(5, new List<string>() { "A1", "A7" });
            _repo.AddBadge(badge);
            _repo.AddBadge(badgeOne);
        }

        [TestMethod]
        public void AddBadge_ShouldReturnTrue()
        {
            //Arrange 
            Badge badge = new Badge(3, new List<string>() { "A2", "A7" });
            int beforeCount = _repo.GetList().Count;
            //Act
            _repo.AddBadge(badge);
            int afterCount = _repo.GetList().Count;
            //Assert
            Assert.IsTrue(afterCount > beforeCount);
        }

        [TestMethod]
        public void GrantAccess_ShouldReturnTrue()
        {
           bool test = _repo.GrantAccess(4, "A1");
           Assert.IsTrue(test);
        }
        [TestMethod]
        public void RemoveAccess_ShouldBeTrue()
        {
            bool testTwo = _repo.RemoveAccess(5, "A7");
            Assert.IsTrue(testTwo);
        }
    }
}
