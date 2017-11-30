namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderModelChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "Menu", c => c.String());
            AddColumn("dbo.Order", "MenuType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "MenuType");
            DropColumn("dbo.Order", "Menu");
        }
    }
}
