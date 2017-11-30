namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedRecipeDateBridge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecipeDateBridges", "MenuDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RecipeDateBridges", "MenuDate");
        }
    }
}
