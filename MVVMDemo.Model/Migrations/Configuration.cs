namespace MVVMDemo.Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVVMDemo.Model.DemoDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MVVMDemo.Model.DemoDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Departments.Add(new Department
            {
                DepartmentID = default(long),
                Name = "B",
                employess = new System.Collections.Generic.List<Employee>{
                                                    new Employee{
                                                    EmployeeID = default(long),
                                                    Address="AA",
                                                    ContractNumber="AA",
                                                    Designation="AA",
                                                    JoinDate=DateTime.Today,
                                                    Name="AA"
                                                    }
                                                    }
            });
        }
    }
}
