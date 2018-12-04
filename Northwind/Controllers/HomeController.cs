using Northwind.Models;
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

        //public ActionResult Birthday()
        //{
        //    return View();
        //}

        //data from external source
        string[] balloons = { "Red", "Blue", "Green", "Purple" };

        public ActionResult Birthday()
        {
            //The Get - On Page Load

            // create an array of strings
            //string[] balloons = { "Red", "Blue", "Green", "Purple" };
            // "put" the array in the ViewBag
            ViewBag.balloons = balloons;

            return View();
        }

        [HttpPost]
        public ActionResult Birthday(FormCollection form)
        {
            List<string> balloonList = new List<string>();

            //The Post - after form submitted
            //ViewBag.balloons = balloons;
            @ViewBag.ResultName = form["name"];
            @ViewBag.ResultBD = form["birthday"];



            //from lesson 12
            //keys are from the array list we have
            
            foreach (var balloon in balloons)
            {
                var b = form[balloon].Split(',');
                var isChecked = Convert.ToBoolean(b[0]); //not quite right --- now it is
                //if is checked
                if (isChecked)
                {
                    balloonList.Add(balloon); //add name of balloon
                }
            }
            //ViewBag.BalloonList = balloonList;
            
            //ViewBag.BalloonList = balloons;


            //var balloons = form.AllKeys.Where(k => k.StartsWith("balloon")).Select(k => form[k]);

            //ViewBag.cart = balloons;

            ViewBag.cart = balloonList;


            return View("Results");
        }

        public bool IsThisAKeyWeNeed(string x)
        {
            if (x.StartsWith("balloon"))
                return true;
            return false;
        }

        //this would be in different classes
        //public interface IContext { }

        //public class ProductContext : IContext
        //{

        //}

        //                                  (int id)

        

        

        
    }
}