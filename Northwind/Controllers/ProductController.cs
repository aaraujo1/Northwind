using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.Models;
using System.Net;
using Northwind.DataLayer;

namespace Northwind.Controllers
{
    public class ProductController : Controller
    {

        public ActionResult Category()
        {
            //return View();
            // retrieve a list of all categories
            using (Northwnd db = new Northwnd())
            {
                return View(db.Categories.OrderBy(c => c.CategoryName).ToList());
            } 
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Discount()
        {
            using (Northwnd db = new Northwnd())
            {
                return View(db.Discounts.ToList());
            }
        }

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
            Models.Product product = p.Find("100");

            return View(product);
        }

        public ActionResult ProcessOrder(FormCollection form)
        {
            List<Models.Order> orders = new List<Models.Order>();

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
            List<Models.Product> products = productContext.GetAll();



            foreach (var p in products)
            {
                if (Int16.TryParse(form[p.Id], out qty) && qty > 0)
                {
                    orders.Add(new Models.Order { Prod = p, Qty = qty });
                }

                //int qty = Convert.ToInt16(form[p.Id]);
                //orders.Add(new Order { Prod = p, Qty = qty });

            }

            return View(orders);
        }

        public ActionResult Unit2Project()
        {
            Unit2ProjectProductContext p = new Unit2ProjectProductContext();

            

            var products = p.GetAll();

            return View(products);
        }

        //public ActionResult Index(Product model)
        //{
        //    var items = // Your List of data
        //        model.ListName = items.Select(x => new SelectListItem()
        //        {
        //            Text = x.prop,
        //            Value = x.prop2
        //        });
        //}
        public ActionResult Unit2ProjectShipping(FormCollection form)
        {

            return View();
        }

        public ActionResult Unit2ProjectProcessOrder(FormCollection form)
        {
            Data d = new Data();

            List<Models.Order> orders = new List<Models.Order>();

            Int16 qty;

            Unit2ProjectProductContext unit2ProjectProductContext = new Unit2ProjectProductContext();
            List<Models.Product> products = unit2ProjectProductContext.GetAll();



            foreach (var p in products)
            {
                if (Int16.TryParse(form[p.Id], out qty) && qty > 0)
                {
                    orders.Add(new Models.Order { Prod = p, Qty = qty });
                }

               

            }

            ViewBag.Name = form["name"];
            ViewBag.Address = form["address"];
            ViewBag.City = form["city"];
            ViewBag.State = form["state"];
            ViewBag.Zip = form["zip"];

            Person person = new Person
            {
                Name = form["name"],
                Address = form["address"],
                City = form["city"],
                State = form["state"],
                Zip = form["zip"]
            };

            d.order = orders;
            d.person = person;

            //return View(d);

            return View(orders);
        }

        public ActionResult Products(string id)
        {
            ProductContext p = new ProductContext();
            //List<Product> products = new List<Product>();

            if (string.IsNullOrEmpty(id))
            {


                //products = p.GetAll();

                return View(p.GetAll());
            }

            //return View(p.GetAll().Where(x => x.CatId == id));
            //return View(p.Find(id));

            return View(p.FindBy(id));

            //return View(products);

        }
        public ActionResult Categories()
        {
            CategoryContext c = new CategoryContext();



            return View(c.GetAll());

        }

        // GET: Product/Product/1
        public ActionResult Product(int? id) {    
            // if there is no "category" id, return Http Bad Request
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (Northwnd db = new Northwnd())
            {    // save the selected category name to the ViewBag
                 ViewBag.Filter = db.Categories.Find(id).CategoryName;
                // retrieve list of products
                return View(db.Products.Where(p => p.CategoryID == id && p.Discontinued == false).OrderBy(p => p.ProductName).ToList());
            } 


                return View();
        }

        // POST: Product/SearchResults
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchResults(FormCollection Form)
        {
            string SearchString = Form["SearchString"];
            ViewBag.Filter = "Product";
            using (Northwnd db = new Northwnd())
            {
                return View("Product", db.Products.Where(p => p.ProductName.Contains(SearchString) && p.Discontinued == false).OrderBy(p => p.ProductName).ToList());
            }
        }


        public ActionResult Index(int? id, string SearchString)
        {
            ViewBag.Filter = "Products";

            using (var db = new Northwnd())
            {
                var products = db.Products.Where(p => !p.Discontinued);

                // apply searchstring
                if (!string.IsNullOrEmpty(SearchString))
                {
                    ViewBag.Filter += " Matching " + SearchString;
                    products = products.Where(p => p.ProductName.Contains(SearchString));
                }

                // apply id
                if (id != null)
                {
                    products = products.Where(p => p.ProductID == id);
                }

                // retrieve list of products
                return View(products.OrderBy(p => p.ProductName).ToList());
            }
        }

        public ActionResult ProductByCategory(int? id, string SearchString)
        {
            ViewBag.Filter = "Products";

            using (var db = new Northwnd())
            {
                var products = db.Products
                    .Where(p => !p.Discontinued);

                // apply searchstring
                if (!string.IsNullOrEmpty(SearchString))
                {
                    ViewBag.Filter += " Matching " + SearchString;
                    products = products.Where(p => p.ProductName.Contains(SearchString));
                }

                // apply id
                if (id != null)
                {
                    ViewBag.Filter += " in Category " + db.Categories.Find(id)?.CategoryName;
                    products = products.Where(p => p.CategoryID == id);
                }

                // retrieve list of products
                return View("Index", products.OrderBy(p => p.ProductName).ToList());
            }
        }

        // GET: Product/FilterProducts

        //http://localhost:xxxxx/Product/FilterProducts/?SearchString=en&PriceFilter=15
        public JsonResult FilterProducts(int? id, string SearchString, decimal? PriceFilter)
        {
            /*if (priceFilter == null)
                Response.StatusCode = 400;*/

            using (var db = new Northwnd())
            {
                //var Products = db.Products.Where(p => p.Discontinued == false).ToList();
                /*var ProductDTOs = (from p in Products.Where(UnitPrice >= PriceFilter)
                                   orderby p.ProductName
                                   select new
                                   {
                                       p.ProductID,
                                       p.ProductName,
                                       p.QuantityPerUnit,
                                       p.UnitPrice,
                                       p.UnitsInStock
                                   }).ToList();*/



                /*if (id != null)
                {
                    products.Where(p => p.CategoryID == id);
                }*/

                //product data transfer object (DTO)
                var products = db.Products.Where(p => p.UnitPrice >= PriceFilter && p.Discontinued == false)
                    .OrderBy(pn => pn.ProductName)
                    .Select(p => new
                    {
                        p.ProductID,
                        p.ProductName,
                        p.QuantityPerUnit,
                        p.UnitPrice,
                        p.UnitsInStock
                    });




                if (!string.IsNullOrEmpty(SearchString))
                {
                    products.Where(p => p.ProductName.Contains(SearchString));
                }

                var productDTO = products.ToList();

                return Json(productDTO, JsonRequestBehavior.AllowGet);
            }

            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

    }
}