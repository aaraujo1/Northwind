using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        //public string State { get; set; }
        //public Product()
        //{

        //}

        //public List<Product> GetAll()
        ////inline syntax
        //{
        //    return new List<Product>()
        //    {
        //    new Product{Id="100", Name="Car Steering Wheel", Price=50.99},
        //    new Product{Id="101", Name="Luke Skywalker Doll", Price=99.98}
        //    };
        //}

    }

    //should be in other files
    //show they relate to each other
    /*public class Category
    {
        public string Id { get; set; }
        //and other properties
    }

    public class OrderContext
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }

    }

    //entity framework naming convention
    //could be its own class
    public class ProductContext
    {
        //public Product Product { get; set; }

        public List<Product> GetAll()
        //inline syntax
        {
            return new List<Product>()
            {
            new Product{Id="100", Name="Car Steering Wheel", Price=50.99},
            new Product{Id="101", Name="Luke Skywalker Doll", Price=99.98}
            };
        }
    }*/
}