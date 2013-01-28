namespace MVVMDemo.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Long(nullable: false, identity: true),
                        DepartmentName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Designation = c.String(maxLength: 100),
                        Address = c.String(maxLength: 100),
                        ContractNumber = c.String(maxLength: 100),
                        JoinDate = c.DateTime(nullable: false),
                        Departments_DepartmentID = c.Long(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Departments", t => t.Departments_DepartmentID)
                .Index(t => t.Departments_DepartmentID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "Departments_DepartmentID" });
            DropForeignKey("dbo.Employees", "Departments_DepartmentID", "dbo.Departments");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
