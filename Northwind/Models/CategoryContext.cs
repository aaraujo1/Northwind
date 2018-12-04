using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Northwind.Models;

namespace Northwind.Models
{
    //entity framework naming convention
    //could be its own class
    public class CategoryContext //: IContext
    {
        //public Product Product { get; set; }
        List<Category> _categories;

        public CategoryContext()
        {
            _categories = new List<Category>()
            {
                new Category { Id = "1", Name = "Toys" },
                new Category { Id = "2", Name = "Music" } ,
                new Category { Id = "3", Name = "Car" },
            };
        }


        public List<Category> GetAll()
            //inline syntax
        {
            /*return new List<Product>()
            {
            new Product{Id="100", Name="Car Steering Wheel", Price=50.99},
            new Product{Id="101", Name="Luke Skywalker Doll", Price=99.98}
            };*/

            return _categories;
        }

        public Category Find(string id)
        {
            //return new Product { };
            return _categories.Where(p => p.Id == id).SingleOrDefault();
        }

        /*public IEnumerable<Product> FindBy(string id)
        {
            throw new NotImplementedException();
        }*/
    }
}