namespace Lupum_Yolcu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usertable_someRequiredDelete : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Fullname", c => c.String(maxLength: 50));
            AlterColumn("dbo.User", "Password", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.User", "Fullname", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
