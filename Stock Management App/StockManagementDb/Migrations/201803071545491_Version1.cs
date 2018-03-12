namespace StockManagementDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        ItemName = c.String(),
                        ReorderLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CategoryId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.StockIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        StockInQuentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.CategoryId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.StockOuts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quentity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.CompanyId)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockOuts", "ItemId", "dbo.Items");
            DropForeignKey("dbo.StockOuts", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.StockIns", "ItemId", "dbo.Items");
            DropForeignKey("dbo.StockIns", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Items", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropIndex("dbo.StockOuts", new[] { "ItemId" });
            DropIndex("dbo.StockOuts", new[] { "CompanyId" });
            DropIndex("dbo.StockIns", new[] { "ItemId" });
            DropIndex("dbo.StockIns", new[] { "CategoryId" });
            DropIndex("dbo.Items", new[] { "CompanyId" });
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropTable("dbo.StockOuts");
            DropTable("dbo.StockIns");
            DropTable("dbo.Items");
            DropTable("dbo.Companies");
            DropTable("dbo.Categories");
        }
    }
}
