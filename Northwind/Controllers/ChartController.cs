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
        // GET: Chart
        public ActionResult CategorySales()
        {
            using (Northwnd db = new Northwnd())
            {
                return View(db.Categories.OrderBy(c => c.CategoryName).ToList());
            }
        }

        public JsonResult FilterChart(string CategoryName)
        {
            using (Northwnd db = new Northwnd())
            {
                if (CategoryName == null)
                {
                    var categoryInfo =
                        from p in db.Products
                        join c in db.Categories on p.CategoryID equals c.CategoryID
                        join od in db.Order_Details on p.ProductID equals od.ProductID
                        group new { p, c, od } by new { c.CategoryName } into f
                        select new
                        {
                            Name = f.Key.CategoryName,
                            Sum = f.Sum(s =>
                                s.od.Quantity * s.od.UnitPrice * (1 - s.od.Discount))
                        };  //Sum = (od.UnitPrice * od.Quantity * (1 - od.Discount)) };

                    var catInfo = categoryInfo.ToList();

                    return Json(catInfo, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var productInfo =
                        from p in db.Products
                        join c in db.Categories on p.CategoryID equals c.CategoryID
                        join od in db.Order_Details on p.ProductID equals od.ProductID
                        where c.CategoryName == CategoryName
                        group new { p, c, od } by new { p.ProductName } into f
                        select new
                        {
                            Name = f.Key.ProductName,
                            Sum = f.Sum(s =>
    s.od.Quantity * s.od.UnitPrice * (1 - s.od.Discount))
                        };
                    var prodInfo = productInfo.ToList();
                    return Json(prodInfo, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult YearlySales()
        {
            return View();
        }

        public JsonResult YearlySalesData()
        {
            using (Northwnd db = new Northwnd())
            {
                var yearlySalesInfo =
                    from o in db.Orders
                    join od in db.Order_Details on o.OrderID equals od.OrderID
                    group new { o, od } by new { o.OrderDate.Value.Year } into f
                    orderby f.Key.Year
                    select new
                    {
                        Year = f.Key.Year,
                        TotalSales = f.Sum(s => s.od.UnitPrice * s.od.Quantity * (1 - s.od.Discount))
                         
                    };
                var yearSaleInfo = yearlySalesInfo.ToList();
                return Json(yearSaleInfo, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult YearlySalesByCountry()
        {
            using (Northwnd db = new Northwnd())
            {
                return View(db.Orders.GroupBy(c => c.OrderDate.Value.Year).OrderBy(c => c.Key).Select(c => c.Key).ToList());
            }
        }

        public JsonResult test()
        {
            using (Northwnd db = new Northwnd())
            {
                var test = db.Orders.GroupBy(c => c.OrderDate.Value.Year).Select(c => c.Key);
                var test2 = test.ToList();
                return Json(test2, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult YearlySalesByCountryData(int? year)
        {
            using (Northwnd db = new Northwnd())
            {
                if (year == null)
                {
                    var yearlySalesInfo =
                        from o in db.Orders
                        join od in db.Order_Details on o.OrderID equals od.OrderID
                        group new { o, od } by new { o.ShipCountry } into f
                        orderby f.Key
                        select new
                        {
                            Country = f.Key.ShipCountry,
                            TotalSales = f.Sum(s => s.od.UnitPrice * s.od.Quantity * (1 - s.od.Discount))

                        };
                    var yearSaleInfo = yearlySalesInfo.ToList();
                    return Json(yearSaleInfo, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var yearlySalesInfo =
                        from o in db.Orders
                        join od in db.Order_Details on o.OrderID equals od.OrderID
                        where o.OrderDate.Value.Year == year
                        group new { o, od } by new { o.ShipCountry } into f
                        select new
                        {
                            Country = f.Key.ShipCountry,
                            TotalSales = f.Sum(s => s.od.UnitPrice * s.od.Quantity * (1 - s.od.Discount))

                        };
                    var yearSaleInfo = yearlySalesInfo.ToList();
                    return Json(yearSaleInfo, JsonRequestBehavior.AllowGet);
                }
                
            }
        }

    }
}