using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Models
{

    //entity framework naming convention
    //could be its own class
    public class ProductContext
    {
        //public Product Product { get; set; }
        List<Product> _products;

        public ProductContext()
        {
            _products = new List<Product>()
            {
                //new Product { Id = "100", Name = "Car Steering Wheel", Price = 50.99 , CatId="3", category = new us.aaraujo1.Models.Category{Id="3", Name="car"} },
                new Product { Id = "100", Name = "Car Steering Wheel", Price = 50.99 , CatId="3" },
                new Product { Id = "101", Name = "Luke Skywalker Doll", Price = 99.98 ,CatId="1"} ,
                new Product { Id = "102", Name = "Mickey Mouse Doll", Price = 19.98 ,CatId="1"},
                new Product { Id = "103", Name = "Mickey Mouse Club House Soundtrack", Price = 9.98 ,CatId="2"},
                new Product { Id = "104", Name = "Skye Doll", Price = 14.98 ,CatId="1"},
                new Product { Id = "105", Name = "Paw Patrol Soundtrack", Price = 9.98 ,CatId="2"},
                new Product { Id = "106", Name = "Pine Cone Air Freshener", Price = 0.98 ,CatId="3"},
            };
        }


        public List<Product> GetAll()
        //inline syntax
        {
            /*return new List<Product>()
            {
            new Product{Id="100", Name="Car Steering Wheel", Price=50.99},
            new Product{Id="101", Name="Luke Skywalker Doll", Price=99.98},
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

        public IEnumerable<Product> FindBy(string id)
        {
            //return new Product { };
            return _products.Where(p => p.CatId == id);
        }

        //delayed
        public List<Product> FindByAsList(string id)
        {
            //return new Product { };
            return _products.Where(p => p.CatId == id).ToList();
        }
    }
}