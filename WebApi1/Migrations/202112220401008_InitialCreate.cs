namespace WebApi1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpId = c.Int(nullable: false, identity: true),
                        EmpName = c.String(),
                        EmpPosition = c.String(),
                    })
                .PrimaryKey(t => t.EmpId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
