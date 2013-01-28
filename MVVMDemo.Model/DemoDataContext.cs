using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace MVVMDemo.Model
{
    public class DemoDataContext : DbContext
    {
        public DemoDataContext() :base("DemoDatabase")
        {

        }

       public DbSet<Department> Departments { get; set; }
       public DbSet<Employee> Employees { get; set; }
    }
}
