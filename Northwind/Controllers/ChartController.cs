using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.Attributes;
using Northwind.Models;
using Northwind.DataLayer;
using System.Data.Entity;


namespace Northwind.Controllers
{
    public class ChartController : Controller
    {

        //[AllowCrossSiteJson]

        public JsonResult ChartData()
        {
            List<ChartData> cd = new List<ChartData>()
            {
                new ChartData("project A", "81531.946062978"),
                new ChartData("project B", "67313.916593765"),
                new ChartData("project C", "92440.723376746")
            };

            return Json(cd, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SalesByCountry()
        {

            using (Northwnd db = new Northwnd())
            {

                //var dbContext = db.Categories.Include("Products").ToList();
                //var dbContext = db.Order_Details.Include("Products").Include("Categories").ToList();

                /*var dbContext = db.Categories.Include(x => x.Products.Select(o => o.Order_Details)).ToList();
                ViewBag.dbContext = dbContext;*/
                return View(db.Categories.OrderBy(c => c.CategoryName).ToList());
            }
            
        }

        public JsonResult SalesByCountryData()
        {

            using (Northwnd db = new Northwnd())
            {

                //var dbContext = db.Categories.Include("Products").ToList();
                //var dbContext = db.Order_Details.Include("Products").Include("Categories").ToList();

                var dbContext = db.Categories.Include(x => x.Products.Select(o => o.Order_Details)).ToList();
                ViewBag.dbContext = dbContext;
                return Json(dbContext, JsonRequestBehavior.AllowGet);
            }

        }


        public ActionResult CategoryBreakdown()
        {
            return View();
        }

    }
}