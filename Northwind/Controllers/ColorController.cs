using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Controllers
{
    public class ColorController : Controller
    {
        // GET: Color
        public ActionResult PrimaryColor(string color1, string color2)
        {
            return View();
        }
    }
}