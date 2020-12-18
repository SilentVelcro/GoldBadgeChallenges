using CafeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CafeUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private Cafe_Repo _repo = new Cafe_Repo();

        [TestInitialize]
        public void Arrange()
        {

            Cafe Burger = new Cafe(5, "Burger", "Single Beef Burger", "Bun, Beefpatty", 5.00);
            _repo.AddNewMenuItems(Burger);

            Cafe eggs = new Cafe(6, "Eggs", "2 Eggs", "Eggs", 4.25);
            _repo.AddNewMenuItems(eggs);
        }
        [TestMethod]
        public void AddNewMenuItems_ShouldReturnTrue()
        {
            Cafe club = new Cafe(7, "Bacon", "Side of Bacon", "Bacon", 3.75);
            int beforeCount = _repo.GetMenuList().Count;

            _repo.AddNewMenuItems(club);
            int afterCount = _repo.GetMenuList().Count;

            Assert.IsTrue(afterCount > beforeCount);
        }
        [TestMethod]
        public void UpdateExisitingMenuItem_ShouldReturnTrue()
        {
            Cafe doubleBurger = new Cafe(5, "Burger", "Double Beef Burger", "Bun, Beefpatty", 7.00);
            bool test = _repo.UpdateExisitingMenuItem(5, doubleBurger);

            Assert.IsTrue(test);
        }
        [TestMethod]
        public void RemoveItemFromList_ShouldReturnTrue()
        {
            bool testTwo = _repo.RemoveItemFromList(6);
            Assert.IsTrue(testTwo);
        }
    }
}
