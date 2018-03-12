namespace StockManagementDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Companies", "CompanyName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Items", "ItemName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.StockIns", "StockInQuentity", c => c.Double(nullable: false));
            AlterColumn("dbo.StockOuts", "Quentity", c => c.Double(nullable: false));
            CreateIndex("dbo.Categories", "CategoryName", unique: true, name: "Ix_CategoryName");
            CreateIndex("dbo.Companies", "CompanyName", unique: true, name: "Ix_CompanyName");
            CreateIndex("dbo.Items", "ItemName", unique: true, name: "Ix_ItemName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Items", "Ix_ItemName");
            DropIndex("dbo.Companies", "Ix_CompanyName");
            DropIndex("dbo.Categories", "Ix_CategoryName");
            AlterColumn("dbo.StockOuts", "Quentity", c => c.Int(nullable: false));
            AlterColumn("dbo.StockIns", "StockInQuentity", c => c.Int(nullable: false));
            AlterColumn("dbo.Items", "ItemName", c => c.String(nullable: false));
            AlterColumn("dbo.Companies", "CompanyName", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
        }
    }
}
