using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DRS.Test
{
    [TestClass]
    public class DataManagerTests
    {
        private readonly DataManager.DataManager _dataManager;

        public DataManagerTests()
        {
            _dataManager = new DataManager.DataManager();
        }

        [TestMethod]
        public void Should_Fetch_All_Users()
        {
            var users = _dataManager.GetAllUsers();

            Assert.IsTrue(users.Count > 0);

        }

        [TestMethod]
        public void Should_Return_User_By_Id()
        {
            var user = _dataManager.GetUserById(1);

            Assert.IsTrue(user != null);

        }

        [TestMethod]
        public void Should_Fetch_All_Drinks()
        {
            var drinks = _dataManager.GetAllDrinks();

            Assert.IsTrue(drinks.Count > 0);

        }

        [TestMethod]
        public void Should_Fetch_All_Drinks_By_Type()
        {
            var drinks = _dataManager.GetDrinksByType(1);

            Assert.IsTrue(drinks.Count > 0);

        }
    }
}
