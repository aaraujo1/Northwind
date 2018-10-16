using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTMLHelpers.Models
{
    public class BirthdayModel
    {
        public string Name { get; set; }
        public string Birthday { get; set; }
        public Balloons[] Balloons { get; set; }

    }

    public class Balloons
    {
        public Boolean Red { get; set; }
        public Boolean Blue { get; set; }
        public Boolean Green { get; set; }
        public Boolean Purple { get; set; }
    }
}