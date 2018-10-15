using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Controllers
{
    public class BankController : Controller
    {
        // GET: Bank
        public ActionResult Index()
        {
            return View();
        }

        [HandleError(ExceptionType = typeof(FormatException), View = "BankError")]
        public ActionResult Test(string id)
        {

            double num1 = Double.Parse(id);
            ViewBag.value = num1;

            /*try
            {
                //double num1 = Double.Parse(id);
                //ViewBag.value = num1;
            }
            catch(Exception ex)
            {
                //System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                //if fails, do this
                //example, close file or database
                //num1 = 0.0;
            }*/
            return View();
        }

        //public ActionResult Debit(int id)
        public double Debit(double amount)
        {
            double balance = 100.10;

            return balance - amount;
            //return View();
        }
    }
}