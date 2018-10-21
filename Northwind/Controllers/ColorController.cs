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
        /*public ActionResult PrimaryColor(string color1, string color2)
        {
            return View();
        }*/

        public ActionResult PrimaryColor(FormCollection form)
        {
            ViewBag.Color1 = form["color1"];
            ViewBag.Color2 = form["color2"];
            if (ViewBag.Color1 == "red" && ViewBag.Color2 == "red") { ViewBag.Color3 = "red"; }
            if (ViewBag.Color1 == "blue" && ViewBag.Color2 == "blue") { ViewBag.Color3 = "blue"; }
            if (ViewBag.Color1 == "green" && ViewBag.Color2 == "green") { ViewBag.Color3 = "green"; }
            if ((ViewBag.Color1 == "red" && ViewBag.Color2 == "blue") ||
                (ViewBag.Color1 == "blue" && ViewBag.Color2 == "red")) { ViewBag.Color3 = "magenta"; }
            if ((ViewBag.Color1 == "red" && ViewBag.Color2 == "green") ||
                (ViewBag.Color1 == "green" && ViewBag.Color2 == "red")) { ViewBag.Color3 = "yellow"; }
            if ((ViewBag.Color1 == "green" && ViewBag.Color2 == "blue") ||
                (ViewBag.Color1 == "blue" && ViewBag.Color2 == "green")) { ViewBag.Color3 = "cyan"; }
            return View();
        }
    }
}