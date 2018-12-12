using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.DataLayer;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        // POST: Cart/AddToCart
        [HttpPost]
        public JsonResult AddToCart(CartDTO cartDTO)
        {
            //getting mapped by serializer 
            //make sure its valid
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return Json(new { }, JsonRequestBehavior.AllowGet);
            }

            // create cart item from Json object
            Cart sc = new Cart();

            sc.ProductID = cartDTO.ProductID;
            sc.CustomerID = cartDTO.CustomerID;
            sc.Quantity = cartDTO.Quantity;

            //database
            using (var db = new Northwnd())
            {
                // add the product to the customer’s cart
                //db.Carts.Add(sc);
                //db.SaveChanges();

                // if there is a duplicate product id in cart, simply update the quantity
                //if (db.Carts.Where(c=>c.ProductID == sc.ProductID && c.CustomerID == sc.CustomerID).Any())
                if (db.Carts.Any(c => c.ProductID == sc.ProductID && c.CustomerID == sc.CustomerID))
                {
                    // this product is already in the customer's cart,
                    // update the existing cart item's quantity
                    //Cart cart = db.Carts.Where(c => c.ProductID == sc.ProductID && c.CustomerID == sc.CustomerID).FirstOrDefault();
                    //gets the cart first
                    Cart cart = db.Carts.FirstOrDefault(c => c.ProductID == sc.ProductID && c.CustomerID == sc.CustomerID);
                    cart.Quantity += sc.Quantity;
                    sc = new Cart()
                    {
                        CartID = cart.CartID,
                        ProductID = cart.ProductID,
                        CustomerID = cart.CustomerID,
                        Quantity = cart.Quantity
                    };
                }
                else
                {
                    // this product is not in the customer's cart, add the product
                    db.Carts.Add(sc);
                }
                db.SaveChanges();
            }

            return Json(sc, JsonRequestBehavior.AllowGet);
        }
    }
}