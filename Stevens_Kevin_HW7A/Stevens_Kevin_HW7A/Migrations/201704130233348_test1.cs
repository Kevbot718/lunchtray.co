namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "OKToText", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Major", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "FName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "FName", c => c.String());
            DropColumn("dbo.AspNetUsers", "Major");
            DropColumn("dbo.AspNetUsers", "OKToText");
            DropColumn("dbo.AspNetUsers", "LName");
        }
    }
}
