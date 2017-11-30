namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bridgetable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.RecipeViewModel", name: "Date_MenuNumber", newName: "MenuDate_MenuNumber");
            RenameIndex(table: "dbo.RecipeViewModel", name: "IX_Date_MenuNumber", newName: "IX_MenuDate_MenuNumber");
            CreateTable(
                "dbo.RecipeDateBridges",
                c => new
                    {
                        MenuNumber = c.Int(nullable: false),
                        RecipeViewModelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MenuNumber, t.RecipeViewModelID })
                .ForeignKey("dbo.Dates", t => t.MenuNumber, cascadeDelete: true)
                .ForeignKey("dbo.RecipeViewModel", t => t.RecipeViewModelID, cascadeDelete: true)
                .Index(t => t.MenuNumber)
                .Index(t => t.RecipeViewModelID);
            
            AddColumn("dbo.Dates", "RecipeName", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeDateBridges", "RecipeViewModelID", "dbo.RecipeViewModel");
            DropForeignKey("dbo.RecipeDateBridges", "MenuNumber", "dbo.Dates");
            DropIndex("dbo.RecipeDateBridges", new[] { "RecipeViewModelID" });
            DropIndex("dbo.RecipeDateBridges", new[] { "MenuNumber" });
            DropColumn("dbo.Dates", "RecipeName");
            DropTable("dbo.RecipeDateBridges");
            RenameIndex(table: "dbo.RecipeViewModel", name: "IX_MenuDate_MenuNumber", newName: "IX_Date_MenuNumber");
            RenameColumn(table: "dbo.RecipeViewModel", name: "MenuDate_MenuNumber", newName: "Date_MenuNumber");
        }
    }
}
