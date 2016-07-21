using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DRS.Test
{
    [TestClass]
    public class ServiceManagerTests
    {
        private readonly ServiceManager.ServiceManager _serviceManager;

        public ServiceManagerTests()
        {
            _serviceManager = new ServiceManager.ServiceManager();
        }

        [TestMethod]
        public void Should_Return_User_By_Id()
        {
            var user = _serviceManager.GetUserById(1);

            Assert.IsTrue(user != null);

        }

        [TestMethod]
        public void Should_Fetch_All_Drinks()
        {
            var drinks = _serviceManager.GetAllDrinks();

            Assert.IsTrue(drinks.Count > 0);

        }

        [TestMethod]
        public void Should_Fetch_All_Drinks_By_Type()
        {
            var drinks = _serviceManager.GetDrinksByType(Enums.DrinkType.Cold);

            Assert.IsTrue(drinks.Count > 0 && drinks.FirstOrDefault().Type.Equals(Enums.DrinkType.Cold));

        }
    }
}
