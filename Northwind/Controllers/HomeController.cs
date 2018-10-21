using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTMLHelpers.Controllers
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
            //List<string> balloonList = new List<string>();

            //The Post - after form submitted
            //ViewBag.balloons = balloons;
            @ViewBag.ResultName = form["name"];
            @ViewBag.ResultBD = form["birthday"];

            var balloons = form.AllKeys.Where(k => k.StartsWith("balloon")).Select(k => form[k]);

            //from lesson 12
            //keys are from the array list we have
            /*
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
            ViewBag.BalloonList = balloonList;
            */
            //ViewBag.BalloonList = balloons;


            ViewBag.cart = balloons;




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
        public ActionResult DisplayProducts()
        {
            //ViewBag.ProductList = Products;

            //pass in model to view
            //this is bad and hard to test because it's instantiating in the method
            //it's the dependent on a class
            ProductContext p = new ProductContext();

            //DatebaseContext db = GetAllDataById(id);

            //var products = p.GetAll();

            //return View(p.GetAll());

            var products = p.GetAll();

            return View(products);

        }

        public ActionResult GetProduct()
        {
            //it's the dependant on a class
            ProductContext p = new ProductContext();
            Product product = p.Find("100");

            return View(product);
        }

        public ActionResult ProcessOrder(FormCollection form)
        {
            List<Order> orders = new List<Order>();

            //we have acces to the form
            //better than form[p.Id]

            Int16 qty;
            /*ProductContext productContext = new ProductContext();
            List<Product> products = productContext.GetAll();

            

            foreach (var key in form.AllKeys)
            {
                //not all
                //if 0
                if (Int16.TryParse(form[key], out qty) && qty > 0)
                {
                    //orders.Add(new Order { ProductKey = key, Qty = qty });
                    var p = productContext.Find(key);
                    orders.Add(new Order { Prod = p, Qty = qty });
                }
            }*/


            //it's the dependant on a class
            ProductContext productContext = new ProductContext();
            List<Product> products = productContext.GetAll();

            

            foreach (var p in products)
            {
                if(Int16.TryParse(form[p.Id], out qty) && qty > 0)
                {
                    orders.Add(new Order { Prod = p, Qty = qty });
                }

                //int qty = Convert.ToInt16(form[p.Id]);
                //orders.Add(new Order { Prod = p, Qty = qty });

            }
            
            return View(orders);
        }
    }
}