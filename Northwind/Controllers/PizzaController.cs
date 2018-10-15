using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Bake()
        {
            ViewBag.fav = "Hawaiian";
            return View();
        }
    }
}