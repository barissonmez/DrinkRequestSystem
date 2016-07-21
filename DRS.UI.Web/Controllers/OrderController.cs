using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DRS.UI.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly ServiceManager.ServiceManager _serviceManager;

        public OrderController()
        {
            _serviceManager = new ServiceManager.ServiceManager();
            
        }

        public JsonResult Create(int id)
        {
            var result = _serviceManager.CreateOrder(id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            var result = _serviceManager.DeleteOrder(id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Today()
        {
            var result = _serviceManager.GetTodaysOrders();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
