namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeDateBridges", "RecipeViewModelID", "dbo.RecipeViewModel");
            DropIndex("dbo.RecipeDateBridges", new[] { "MenuNumber" });
            DropIndex("dbo.RecipeDateBridges", new[] { "RecipeViewModelID" });
            DropTable("dbo.RecipeDateBridges");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.RecipeDateBridges",
                c => new
                {
                    RDB = c.Int(nullable: false),
                    MenuNumber = c.Int(nullable: false),
                    RecipeViewModelID = c.Int(nullable: false),
                    MenuDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.RDB, t.MenuNumber, t.RecipeViewModelID });

        }
    }
}
