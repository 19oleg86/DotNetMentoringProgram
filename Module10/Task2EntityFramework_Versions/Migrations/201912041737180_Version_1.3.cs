namespace Task2EntityFramework_Versions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version_13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegionDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Phone = c.String(),
                        FoundationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
            DropTable("dbo.Regions");
        }
    }
}
