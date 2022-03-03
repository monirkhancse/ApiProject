using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyWebApiCore.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Dep { get; set; }
        public string Address { get; set; }
    }
}