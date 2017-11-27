namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeIngredientBridges", "IngredientID", "dbo.Ingredients");
            DropForeignKey("dbo.Recipes", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.RecipeIngredientBridges", "RecipeID", "dbo.Recipes");
            DropIndex("dbo.RecipeIngredientBridges", new[] { "RecipeID" });
            DropIndex("dbo.RecipeIngredientBridges", new[] { "IngredientID" });
            DropIndex("dbo.Recipes", new[] { "Order_OrderID" });
            CreateTable(
                "dbo.RecipeIngredients",
                c => new
                    {
                        Recipe_RecipeID = c.Int(nullable: false),
                        Ingredient_IngredientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_RecipeID, t.Ingredient_IngredientID })
                .ForeignKey("dbo.Recipes", t => t.Recipe_RecipeID, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_IngredientID, cascadeDelete: true)
                .Index(t => t.Recipe_RecipeID)
                .Index(t => t.Ingredient_IngredientID);
            
            AddColumn("dbo.Recipes", "Ingredient", c => c.String());
            AddColumn("dbo.Recipes", "Ingredient2", c => c.String());
            AddColumn("dbo.Recipes", "Ingredient3", c => c.String());
            AddColumn("dbo.Recipes", "WorkInstructions", c => c.String());
            DropColumn("dbo.Recipes", "PrepTime");
            DropColumn("dbo.Recipes", "CookTime");
            DropColumn("dbo.Recipes", "TotalCost");
            DropColumn("dbo.Recipes", "Notes");
            DropColumn("dbo.Recipes", "Order_OrderID");
            DropTable("dbo.RecipeIngredientBridges");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RecipeIngredientBridges",
                c => new
                    {
                        RecipeID = c.Int(nullable: false),
                        IngredientID = c.Int(nullable: false),
                        MeasurementType = c.Int(nullable: false),
                        MeasurementQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecipeID, t.IngredientID });
            
            AddColumn("dbo.Recipes", "Order_OrderID", c => c.Int());
            AddColumn("dbo.Recipes", "Notes", c => c.String());
            AddColumn("dbo.Recipes", "TotalCost", c => c.Double(nullable: false));
            AddColumn("dbo.Recipes", "CookTime", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "PrepTime", c => c.Int(nullable: false));
            DropForeignKey("dbo.RecipeIngredients", "Ingredient_IngredientID", "dbo.Ingredients");
            DropForeignKey("dbo.RecipeIngredients", "Recipe_RecipeID", "dbo.Recipes");
            DropIndex("dbo.RecipeIngredients", new[] { "Ingredient_IngredientID" });
            DropIndex("dbo.RecipeIngredients", new[] { "Recipe_RecipeID" });
            DropColumn("dbo.Recipes", "WorkInstructions");
            DropColumn("dbo.Recipes", "Ingredient3");
            DropColumn("dbo.Recipes", "Ingredient2");
            DropColumn("dbo.Recipes", "Ingredient");
            DropTable("dbo.RecipeIngredients");
            CreateIndex("dbo.Recipes", "Order_OrderID");
            CreateIndex("dbo.RecipeIngredientBridges", "IngredientID");
            CreateIndex("dbo.RecipeIngredientBridges", "RecipeID");
            AddForeignKey("dbo.RecipeIngredientBridges", "RecipeID", "dbo.Recipes", "RecipeID", cascadeDelete: true);
            AddForeignKey("dbo.Recipes", "Order_OrderID", "dbo.Orders", "OrderID");
            AddForeignKey("dbo.RecipeIngredientBridges", "IngredientID", "dbo.Ingredients", "IngredientID", cascadeDelete: true);
        }
    }
}
