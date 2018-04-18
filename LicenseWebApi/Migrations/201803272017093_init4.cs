namespace LicenseWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "owner_Id", "dbo.Owners");
            DropForeignKey("dbo.Licenses", "product_Id", "dbo.Products");
            DropIndex("dbo.Licenses", new[] { "product_Id" });
            DropIndex("dbo.Products", new[] { "owner_Id" });
            AlterColumn("dbo.Licenses", "product_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "owner_id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "owner_id", c => c.Int());
            AlterColumn("dbo.Licenses", "product_id", c => c.Int());
            CreateIndex("dbo.Products", "owner_Id");
            CreateIndex("dbo.Licenses", "product_Id");
            AddForeignKey("dbo.Licenses", "product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Products", "owner_Id", "dbo.Owners", "Id");
        }
    }
}
