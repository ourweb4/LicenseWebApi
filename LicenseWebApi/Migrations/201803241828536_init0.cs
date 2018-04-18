namespace LicenseWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init0 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "owner_Id", c => c.Int());
            CreateIndex("dbo.Products", "owner_Id");
            AddForeignKey("dbo.Products", "owner_Id", "dbo.Owners", "Id");
            DropColumn("dbo.Products", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "OwnerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "owner_Id", "dbo.Owners");
            DropIndex("dbo.Products", new[] { "owner_Id" });
            DropColumn("dbo.Products", "owner_Id");
        }
    }
}
