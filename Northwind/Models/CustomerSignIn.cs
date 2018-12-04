using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormData.Models
{
    public class CustomerSignIn
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Password Required")]
        //[RegularExpression("fo*")]
        public string Password { get; set; }
    }
    /*public class MyValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            //return base.IsValid(value);
            return true;
        }
    }*/
}