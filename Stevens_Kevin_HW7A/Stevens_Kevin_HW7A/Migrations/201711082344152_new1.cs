namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeIngredients", "Recipe_RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.RecipeIngredients", "Ingredient_IngredientID", "dbo.Ingredients");
            DropIndex("dbo.RecipeIngredients", new[] { "Recipe_RecipeID" });
            DropIndex("dbo.RecipeIngredients", new[] { "Ingredient_IngredientID" });
            CreateTable(
                "dbo.RecipeIngredientBridges",
                c => new
                    {
                        RecipeID = c.Int(nullable: false),
                        IngredientID = c.Int(nullable: false),
                        MeasurementType = c.Int(nullable: false),
                        MeasurementQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecipeID, t.IngredientID })
                .ForeignKey("dbo.Ingredients", t => t.IngredientID, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.RecipeID, cascadeDelete: true)
                .Index(t => t.RecipeID)
                .Index(t => t.IngredientID);
            
            AddColumn("dbo.Recipes", "PrepTime", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "CookTime", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "TotalCost", c => c.Double(nullable: false));
            AddColumn("dbo.Recipes", "Notes", c => c.String());
            AddColumn("dbo.Recipes", "InstructionID", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "Order_OrderID", c => c.Int());
            CreateIndex("dbo.Recipes", "Order_OrderID");
            AddForeignKey("dbo.Recipes", "Order_OrderID", "dbo.Orders", "OrderID");
            DropColumn("dbo.Recipes", "Ingredient");
            DropColumn("dbo.Recipes", "Ingredient2");
            DropColumn("dbo.Recipes", "Ingredient3");
            DropColumn("dbo.Recipes", "WorkInstructions");
            DropTable("dbo.RecipeIngredients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RecipeIngredients",
                c => new
                    {
                        Recipe_RecipeID = c.Int(nullable: false),
                        Ingredient_IngredientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_RecipeID, t.Ingredient_IngredientID });
            
            AddColumn("dbo.Recipes", "WorkInstructions", c => c.String());
            AddColumn("dbo.Recipes", "Ingredient3", c => c.String());
            AddColumn("dbo.Recipes", "Ingredient2", c => c.String());
            AddColumn("dbo.Recipes", "Ingredient", c => c.String());
            DropForeignKey("dbo.RecipeIngredientBridges", "RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.RecipeIngredientBridges", "IngredientID", "dbo.Ingredients");
            DropIndex("dbo.Recipes", new[] { "Order_OrderID" });
            DropIndex("dbo.RecipeIngredientBridges", new[] { "IngredientID" });
            DropIndex("dbo.RecipeIngredientBridges", new[] { "RecipeID" });
            DropColumn("dbo.Recipes", "Order_OrderID");
            DropColumn("dbo.Recipes", "InstructionID");
            DropColumn("dbo.Recipes", "Notes");
            DropColumn("dbo.Recipes", "TotalCost");
            DropColumn("dbo.Recipes", "CookTime");
            DropColumn("dbo.Recipes", "PrepTime");
            DropTable("dbo.RecipeIngredientBridges");
            CreateIndex("dbo.RecipeIngredients", "Ingredient_IngredientID");
            CreateIndex("dbo.RecipeIngredients", "Recipe_RecipeID");
            AddForeignKey("dbo.RecipeIngredients", "Ingredient_IngredientID", "dbo.Ingredients", "IngredientID", cascadeDelete: true);
            AddForeignKey("dbo.RecipeIngredients", "Recipe_RecipeID", "dbo.Recipes", "RecipeID", cascadeDelete: true);
        }
    }
}
