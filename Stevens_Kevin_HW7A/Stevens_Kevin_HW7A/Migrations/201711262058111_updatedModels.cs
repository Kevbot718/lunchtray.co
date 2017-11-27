namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedModels : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Ingredients", newName: "Ingredient");
            RenameTable(name: "dbo.Orders", newName: "Order");
            RenameTable(name: "dbo.Recipes", newName: "Recipe");
            RenameTable(name: "dbo.Subscriptions", newName: "Subscription");
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
                        Name = c.String(),
                        MeasurementType = c.Int(nullable: false),
                        MeasurementQuantity = c.Int(nullable: false),
                        RecipeViewModel_RecipeViewModelID = c.Int(),
                    })
                .PrimaryKey(t => new { t.RecipeID, t.IngredientID })
                .ForeignKey("dbo.Ingredient", t => t.IngredientID, cascadeDelete: true)
                .ForeignKey("dbo.Recipe", t => t.RecipeID, cascadeDelete: true)
                .ForeignKey("dbo.RecipeViewModels", t => t.RecipeViewModel_RecipeViewModelID)
                .Index(t => t.RecipeID)
                .Index(t => t.IngredientID)
                .Index(t => t.RecipeViewModel_RecipeViewModelID);
            
            CreateTable(
                "dbo.RecipeViewModels",
                c => new
                    {
                        RecipeViewModelID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IngredientName = c.String(),
                        MeasurementType = c.Int(nullable: false),
                        MeasurementQuantity = c.Int(nullable: false),
                        PrepTime = c.Int(nullable: false),
                        CookTime = c.Int(nullable: false),
                        TotalCost = c.Double(nullable: false),
                        Notes = c.String(),
                        Instructions = c.String(),
                        Order_OrderID = c.Int(),
                    })
                .PrimaryKey(t => t.RecipeViewModelID)
                .ForeignKey("dbo.Order", t => t.Order_OrderID)
                .Index(t => t.Order_OrderID);
            
            AddColumn("dbo.Recipe", "PrepTime", c => c.Int(nullable: false));
            AddColumn("dbo.Recipe", "CookTime", c => c.Int(nullable: false));
            AddColumn("dbo.Recipe", "TotalCost", c => c.Double(nullable: false));
            AddColumn("dbo.Recipe", "Notes", c => c.String());
            AddColumn("dbo.Recipe", "Instructions", c => c.String());
            AddColumn("dbo.Recipe", "Order_OrderID", c => c.Int());
            AddColumn("dbo.Subscription", "Meal", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipe", "Order_OrderID");
            AddForeignKey("dbo.Recipe", "Order_OrderID", "dbo.Order", "OrderID");
            DropColumn("dbo.Recipe", "Ingredient");
            DropColumn("dbo.Recipe", "Ingredient2");
            DropColumn("dbo.Recipe", "Ingredient3");
            DropColumn("dbo.Recipe", "WorkInstructions");
            DropColumn("dbo.Subscription", "Meals");
            DropColumn("dbo.AspNetUsers", "Major");
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
            
            AddColumn("dbo.AspNetUsers", "Major", c => c.Int(nullable: false));
            AddColumn("dbo.Subscription", "Meals", c => c.Int(nullable: false));
            AddColumn("dbo.Recipe", "WorkInstructions", c => c.String());
            AddColumn("dbo.Recipe", "Ingredient3", c => c.String());
            AddColumn("dbo.Recipe", "Ingredient2", c => c.String());
            AddColumn("dbo.Recipe", "Ingredient", c => c.String());
            DropForeignKey("dbo.RecipeIngredientBridges", "RecipeViewModel_RecipeViewModelID", "dbo.RecipeViewModels");
            DropForeignKey("dbo.RecipeViewModels", "Order_OrderID", "dbo.Order");
            DropForeignKey("dbo.RecipeIngredientBridges", "RecipeID", "dbo.Recipe");
            DropForeignKey("dbo.Recipe", "Order_OrderID", "dbo.Order");
            DropForeignKey("dbo.RecipeIngredientBridges", "IngredientID", "dbo.Ingredient");
            DropIndex("dbo.RecipeViewModels", new[] { "Order_OrderID" });
            DropIndex("dbo.Recipe", new[] { "Order_OrderID" });
            DropIndex("dbo.RecipeIngredientBridges", new[] { "RecipeViewModel_RecipeViewModelID" });
            DropIndex("dbo.RecipeIngredientBridges", new[] { "IngredientID" });
            DropIndex("dbo.RecipeIngredientBridges", new[] { "RecipeID" });
            DropColumn("dbo.Subscription", "Meal");
            DropColumn("dbo.Recipe", "Order_OrderID");
            DropColumn("dbo.Recipe", "Instructions");
            DropColumn("dbo.Recipe", "Notes");
            DropColumn("dbo.Recipe", "TotalCost");
            DropColumn("dbo.Recipe", "CookTime");
            DropColumn("dbo.Recipe", "PrepTime");
            DropTable("dbo.RecipeViewModels");
            DropTable("dbo.RecipeIngredientBridges");
            CreateIndex("dbo.RecipeIngredients", "Ingredient_IngredientID");
            CreateIndex("dbo.RecipeIngredients", "Recipe_RecipeID");
            AddForeignKey("dbo.RecipeIngredients", "Ingredient_IngredientID", "dbo.Ingredients", "IngredientID", cascadeDelete: true);
            AddForeignKey("dbo.RecipeIngredients", "Recipe_RecipeID", "dbo.Recipes", "RecipeID", cascadeDelete: true);
            RenameTable(name: "dbo.Subscription", newName: "Subscriptions");
            RenameTable(name: "dbo.Recipe", newName: "Recipes");
            RenameTable(name: "dbo.Order", newName: "Orders");
            RenameTable(name: "dbo.Ingredient", newName: "Ingredients");
        }
    }
}
