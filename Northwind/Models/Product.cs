using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTMLHelpers.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        ///  Price of the product
        /// </summary>
        public double Price { get; set; }

        public List<Product> Get()
        {
            return new List<Product>()
            {
            new Product { Id = "100", Name = "Bag(s) of Marshmallows", Price = .99 },
            new Product { Id = "101", Name = "Box(es) of Graham Crackers", Price = 1.99 },
            new Product { Id = "102", Name = "Package(s) of Chocolate Bars", Price = 2.99 }
            };
        }
    }
}