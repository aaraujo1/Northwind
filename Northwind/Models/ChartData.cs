using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Models
{
    public class ChartData
    {

        public string CompanyName { get; set; }
        public string PresentWorth { get; set; }

        public ChartData(string name, string worth)
        {
            CompanyName = name;
            PresentWorth = worth;

        }
    }
}