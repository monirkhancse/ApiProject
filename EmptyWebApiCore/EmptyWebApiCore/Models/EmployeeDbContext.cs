using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmptyWebApiCore.Models
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext() : base("EmployeeDbContext")
        {

        }
        public DbSet<Employee> employees { get; set; }
    }
   
}