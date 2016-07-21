using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRS.DTO;
using DRS.UI.Web.Models;

namespace DRS.UI.Web.Controllers
{
    public class DrinkController : Controller
    {
        private readonly ServiceManager.ServiceManager _serviceManager;

        public DrinkController()
        {
            _serviceManager = new ServiceManager.ServiceManager();
            
        }

        public JsonResult GetAll()
        {
            var result = new DrinkListResponseModel
            {
                ColdDrinks = _serviceManager.GetDrinksByType(Enums.DrinkType.Cold),
                HotDrinks = _serviceManager.GetDrinksByType(Enums.DrinkType.Hot)
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
