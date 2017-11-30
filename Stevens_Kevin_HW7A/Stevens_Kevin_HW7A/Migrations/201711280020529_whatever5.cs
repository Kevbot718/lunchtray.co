namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatever5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Order", "Menu");
            DropColumn("dbo.Order", "MenuType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "MenuType", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "Menu", c => c.String());
        }
    }
}
