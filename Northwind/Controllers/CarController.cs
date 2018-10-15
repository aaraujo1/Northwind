using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Controllers
{
    public class CarController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            
            return View();
        }

        public ActionResult Manufacturer(string name)
        {
            ViewBag.ManufacturerName = name;
            return View();
        }
    }
}