namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedingredients : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecipeIngredientBridges", "Name", c => c.String());
            AddColumn("dbo.RecipeIngredientBridges", "RecipeViewModel_RecipeViewModelID", c => c.Int());
            AddColumn("dbo.Instructions", "RecipeViewModel_RecipeViewModelID", c => c.Int());
            AddColumn("dbo.RecipeViewModels", "Name", c => c.String());
            AddColumn("dbo.RecipeViewModels", "IngredientName", c => c.String());
            AddColumn("dbo.RecipeViewModels", "MeasurementType", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeViewModels", "MeasurementQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeViewModels", "PrepTime", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeViewModels", "CookTime", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeViewModels", "TotalCost", c => c.Double(nullable: false));
            AddColumn("dbo.RecipeViewModels", "Notes", c => c.String());
            AddColumn("dbo.RecipeViewModels", "InstructionID", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeViewModels", "Order_OrderID", c => c.Int());
            CreateIndex("dbo.RecipeIngredientBridges", "RecipeViewModel_RecipeViewModelID");
            CreateIndex("dbo.Instructions", "RecipeViewModel_RecipeViewModelID");
            CreateIndex("dbo.RecipeViewModels", "Order_OrderID");
            AddForeignKey("dbo.Instructions", "RecipeViewModel_RecipeViewModelID", "dbo.RecipeViewModels", "RecipeViewModelID");
            AddForeignKey("dbo.RecipeViewModels", "Order_OrderID", "dbo.Orders", "OrderID");
            AddForeignKey("dbo.RecipeIngredientBridges", "RecipeViewModel_RecipeViewModelID", "dbo.RecipeViewModels", "RecipeViewModelID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeIngredientBridges", "RecipeViewModel_RecipeViewModelID", "dbo.RecipeViewModels");
            DropForeignKey("dbo.RecipeViewModels", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Instructions", "RecipeViewModel_RecipeViewModelID", "dbo.RecipeViewModels");
            DropIndex("dbo.RecipeViewModels", new[] { "Order_OrderID" });
            DropIndex("dbo.Instructions", new[] { "RecipeViewModel_RecipeViewModelID" });
            DropIndex("dbo.RecipeIngredientBridges", new[] { "RecipeViewModel_RecipeViewModelID" });
            DropColumn("dbo.RecipeViewModels", "Order_OrderID");
            DropColumn("dbo.RecipeViewModels", "InstructionID");
            DropColumn("dbo.RecipeViewModels", "Notes");
            DropColumn("dbo.RecipeViewModels", "TotalCost");
            DropColumn("dbo.RecipeViewModels", "CookTime");
            DropColumn("dbo.RecipeViewModels", "PrepTime");
            DropColumn("dbo.RecipeViewModels", "MeasurementQuantity");
            DropColumn("dbo.RecipeViewModels", "MeasurementType");
            DropColumn("dbo.RecipeViewModels", "IngredientName");
            DropColumn("dbo.RecipeViewModels", "Name");
            DropColumn("dbo.Instructions", "RecipeViewModel_RecipeViewModelID");
            DropColumn("dbo.RecipeIngredientBridges", "RecipeViewModel_RecipeViewModelID");
            DropColumn("dbo.RecipeIngredientBridges", "Name");
        }
    }
}
