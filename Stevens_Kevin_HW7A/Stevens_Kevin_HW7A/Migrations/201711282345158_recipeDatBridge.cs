namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recipeDatBridge : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.RecipeDateBridges");
            AddColumn("dbo.RecipeDateBridges", "RDB", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.RecipeDateBridges", new[] { "RDB", "MenuNumber", "RecipeViewModelID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.RecipeDateBridges");
            DropColumn("dbo.RecipeDateBridges", "RDB");
            AddPrimaryKey("dbo.RecipeDateBridges", new[] { "MenuNumber", "RecipeViewModelID" });
        }
    }
}
