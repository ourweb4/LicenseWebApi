namespace LicenseWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Licenses", "product_Id", c => c.Int());
            CreateIndex("dbo.Licenses", "product_Id");
            AddForeignKey("dbo.Licenses", "product_Id", "dbo.Products", "Id");
            DropColumn("dbo.Licenses", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Licenses", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Licenses", "product_Id", "dbo.Products");
            DropIndex("dbo.Licenses", new[] { "product_Id" });
            DropColumn("dbo.Licenses", "product_Id");
        }
    }
}
