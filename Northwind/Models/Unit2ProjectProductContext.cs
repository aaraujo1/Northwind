using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Models
{

    //entity framework naming convention
    //could be its own class
    public class Unit2ProjectProductContext
    {
        //public Product Product { get; set; }
        List<Product> _products;

        public Unit2ProjectProductContext()
        {
            _products = new List<Product>()
            {
                new Product { Id = "100", Name = "Cheese Puff", Price = 0.19 },
                new Product { Id = "101", Name = "Lamp", Price = 2.19 },
                new Product { Id = "102", Name = "Fishing Pole", Price = 3.87},
                new Product { Id = "103", Name = "Bacon", Price = 1.43},
                new Product { Id = "104", Name = "Firecracker", Price = 2.12},
            };
        }


        public List<Product> GetAll()
        //inline syntax
        {
            /*return new List<Product>()
            {
            new Product { Id = "100", Name="Car Steering Wheel", Price=50.99},
            new Product { Id = "101", Name="Luke Skywalker Doll", Price=99.98},
            new Product { Id = "102", Name = "Bag(s) of Marshmallows", Price = .99},
            new Product { Id = "103", Name = "Box(es) of Graham Crackers", Price = 1.99 },
            new Product { Id = "104", Name = "Package(s) of Chocolate Bars", Price = 2.99 }
            };*/

            return _products;
        }

        public Product Find(string id)
        {
            //return new Product { };
            return _products.Where(p => p.Id == id).SingleOrDefault();
        }
    }
}