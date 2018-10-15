using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        //public ActionResult Stuff(String id)
        public ActionResult Stuff(int id = 0)
        {
            //called id based on route config file
           // @ViewBag.number = id;
            @ViewBag.qty = id;
            return View();
        }

        //a dictionary parameter
        public ActionResult AddNumbers(FormCollection form)
        {
            double num1, num2, num3;

            var num1Success = Double.TryParse(form["num1"], out num1);
            var num2Success = Double.TryParse(form["num2"], out num2);
            var num3Success = Double.TryParse(form["num3"], out num3);

            if (num1Success && num2Success && num3Success)
            {
                ViewBag.Total = num1 + num2 + num3;

                
                ViewBag.a = num1;
                ViewBag.b = num2;
                ViewBag.c = num3;
            }


            //ViewBag.a = form["num1"];
            //ViewBag.b = form["num2"];
            //ViewBag.c = form["num3"];

           // ViewBag.Total = ViewBag.a + ViewBag.b + ViewBag.c;

            return View();
        }

        public ActionResult DisplayList()
        {
            ViewBag.Names = new string[] {"Joe", "Jim", "Janice", "Joan"};
            return View();
        }
    }
}