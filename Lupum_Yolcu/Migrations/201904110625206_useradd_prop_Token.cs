namespace Lupum_Yolcu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useradd_prop_Token : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Token", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Token");
        }
    }
}
