namespace Lupum_Yolcu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somechange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Colors", c => c.String());
            DropColumn("dbo.Product", "Color");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Color", c => c.String());
            DropColumn("dbo.Product", "Colors");
        }
    }
}
