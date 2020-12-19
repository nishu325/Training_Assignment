namespace SourceControlFinalAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModelReady : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        ImagePath = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Experience = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
