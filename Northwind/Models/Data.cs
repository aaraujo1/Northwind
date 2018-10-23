using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Models
{
    public class Data
    {
        public Person person { get; set; }
        public List<Order> order { get; set; }
        public Data()
        {
            this.person = new Person();
            this.order = new List<Order>();
        }
    }
}