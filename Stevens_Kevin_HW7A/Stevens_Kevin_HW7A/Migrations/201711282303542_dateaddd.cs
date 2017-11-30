namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateaddd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dates",
                c => new
                    {
                        MenuNumber = c.Int(nullable: false, identity: true),
                        MenuDate = c.DateTime(nullable: false),
                        RecipeViewModelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MenuNumber);
            
            AddColumn("dbo.RecipeViewModel", "Date_MenuNumber", c => c.Int());
            CreateIndex("dbo.RecipeViewModel", "Date_MenuNumber");
            AddForeignKey("dbo.RecipeViewModel", "Date_MenuNumber", "dbo.Dates", "MenuNumber");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeViewModel", "Date_MenuNumber", "dbo.Dates");
            DropIndex("dbo.RecipeViewModel", new[] { "Date_MenuNumber" });
            DropColumn("dbo.RecipeViewModel", "Date_MenuNumber");
            DropTable("dbo.Dates");
        }
    }
}
