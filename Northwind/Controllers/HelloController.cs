using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public string About()
        {
            return "Test";
        }
    }
}