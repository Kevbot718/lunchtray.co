namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedRecipeName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RecipeViewModels", newName: "RecipeViewModel");
            AddColumn("dbo.RecipeIngredientBridges", "IngredientName", c => c.String());
            AddColumn("dbo.Recipe", "RecipeName", c => c.String());
            AddColumn("dbo.RecipeViewModel", "RecipeName", c => c.String());
            DropColumn("dbo.RecipeIngredientBridges", "Name");
            DropColumn("dbo.Recipe", "Name");
            DropColumn("dbo.RecipeViewModel", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RecipeViewModel", "Name", c => c.String());
            AddColumn("dbo.Recipe", "Name", c => c.String());
            AddColumn("dbo.RecipeIngredientBridges", "Name", c => c.String());
            DropColumn("dbo.RecipeViewModel", "RecipeName");
            DropColumn("dbo.Recipe", "RecipeName");
            DropColumn("dbo.RecipeIngredientBridges", "IngredientName");
            RenameTable(name: "dbo.RecipeViewModel", newName: "RecipeViewModels");
        }
    }
}
