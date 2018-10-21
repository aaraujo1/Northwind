using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Models
{
    //public class Cart
    public class Order
    {
        public Product Prod { get; set; }
        //public string ProductKey { get; set; }
        //public string ProductName { get; set; }
        public int Qty { get; set; }
    }
}