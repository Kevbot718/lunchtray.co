namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ingredientmultipliers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecipeIngredientBridges", "ElementaryMultiplier", c => c.Double(nullable: false));
            AddColumn("dbo.RecipeIngredientBridges", "AdultMultiplier", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RecipeIngredientBridges", "AdultMultiplier");
            DropColumn("dbo.RecipeIngredientBridges", "ElementaryMultiplier");
        }
    }
}
