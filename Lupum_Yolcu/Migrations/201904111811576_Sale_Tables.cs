namespace Lupum_Yolcu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sale_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Market",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Limit = c.Decimal(storeType: "money"),
                        UserId = c.Int(nullable: false),
                        NetworkId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Network", t => t.NetworkId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.NetworkId);
            
            CreateTable(
                "dbo.Network",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductNetworkPrice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        NetworkId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Network", t => t.NetworkId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.NetworkId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        GiftCount = c.Int(nullable: false),
                        Color = c.String(),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Type", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        Color = c.String(maxLength: 50),
                        Count = c.Int(nullable: false),
                        Gift = c.Int(nullable: false),
                        Discount = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        MarketId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Market", t => t.MarketId, cascadeDelete: true)
                .Index(t => t.MarketId);
            
            CreateTable(
                "dbo.Type",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        MarketId = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, storeType: "money"),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Market", t => t.MarketId, cascadeDelete: true)
                .Index(t => t.MarketId);
            
            AddColumn("dbo.Action", "Controller", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Action", "Icon", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Market", "UserId", "dbo.User");
            DropForeignKey("dbo.Payment", "MarketId", "dbo.Market");
            DropForeignKey("dbo.Market", "NetworkId", "dbo.Network");
            DropForeignKey("dbo.Product", "TypeId", "dbo.Type");
            DropForeignKey("dbo.ProductNetworkPrice", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderItem", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "MarketId", "dbo.Market");
            DropForeignKey("dbo.ProductNetworkPrice", "NetworkId", "dbo.Network");
            DropIndex("dbo.Payment", new[] { "MarketId" });
            DropIndex("dbo.Order", new[] { "MarketId" });
            DropIndex("dbo.OrderItem", new[] { "ProductId" });
            DropIndex("dbo.OrderItem", new[] { "OrderId" });
            DropIndex("dbo.Product", new[] { "TypeId" });
            DropIndex("dbo.ProductNetworkPrice", new[] { "NetworkId" });
            DropIndex("dbo.ProductNetworkPrice", new[] { "ProductId" });
            DropIndex("dbo.Market", new[] { "NetworkId" });
            DropIndex("dbo.Market", new[] { "UserId" });
            DropColumn("dbo.Action", "Icon");
            DropColumn("dbo.Action", "Controller");
            DropTable("dbo.Payment");
            DropTable("dbo.Type");
            DropTable("dbo.Order");
            DropTable("dbo.OrderItem");
            DropTable("dbo.Product");
            DropTable("dbo.ProductNetworkPrice");
            DropTable("dbo.Network");
            DropTable("dbo.Market");
        }
    }
}
