using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTMLHelpers.Models
{

    //entity framework naming convention
    //could be its own class
    public class ProductContext
    {
        //public Product Product { get; set; }
        List<Product> _products;

        public ProductContext()
        {
            _products = new List<Product>();
            {
                new Product { Id = "100", Name = "Car Steering Wheel", Price = 50.99 };
                new Product { Id = "101", Name = "Luke Skywalker Doll", Price = 99.98 };
            };
        }


        public List<Product> GetAll()
        //inline syntax
        {
            /*return new List<Product>()
            {
            new Product{Id="100", Name="Car Steering Wheel", Price=50.99},
            new Product{Id="101", Name="Luke Skywalker Doll", Price=99.98}
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