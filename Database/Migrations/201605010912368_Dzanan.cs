namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dzanan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DepId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        Activity = c.Boolean(nullable: false),
                        Department_DepId = c.Int(),
                    })
                .PrimaryKey(t => t.EmpId)
                .ForeignKey("dbo.Departments", t => t.Department_DepId)
                .Index(t => t.Department_DepId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Department_DepId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Department_DepId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
