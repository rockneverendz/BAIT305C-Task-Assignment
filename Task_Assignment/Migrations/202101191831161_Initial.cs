namespace Task_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        FullName = c.String(),
                        Password = c.String(),
                        JoinDate = c.DateTime(nullable: false),
                        Position = c.Int(nullable: false),
                        Team = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Security = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
