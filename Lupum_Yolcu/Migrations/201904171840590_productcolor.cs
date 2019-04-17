namespace Lupum_Yolcu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productcolor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductColor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductColor", "ProductId", "dbo.Product");
            DropIndex("dbo.ProductColor", new[] { "ProductId" });
            DropTable("dbo.ProductColor");
        }
    }
}
