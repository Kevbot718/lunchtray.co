namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIngredientFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecipeViewModel", "IngredientName2", c => c.String());
            AddColumn("dbo.RecipeViewModel", "MeasurementType2", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeViewModel", "MeasurementQuantity2", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeViewModel", "IngredientName3", c => c.String());
            AddColumn("dbo.RecipeViewModel", "MeasurementType3", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeViewModel", "MeasurementQuantity3", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeViewModel", "IngredientName4", c => c.String());
            AddColumn("dbo.RecipeViewModel", "MeasurementType4", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeViewModel", "MeasurementQuantity4", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeViewModel", "IngredientName5", c => c.String());
            AddColumn("dbo.RecipeViewModel", "MeasurementType5", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeViewModel", "MeasurementQuantity5", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeViewModel", "IngredientName6", c => c.String());
            AddColumn("dbo.RecipeViewModel", "MeasurementType6", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeViewModel", "MeasurementQuantity6", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeViewModel", "IngredientName7", c => c.String());
            AddColumn("dbo.RecipeViewModel", "MeasurementType7", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeViewModel", "MeasurementQuantity7", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeViewModel", "IngredientName8", c => c.String());
            AddColumn("dbo.RecipeViewModel", "MeasurementType8", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeViewModel", "MeasurementQuantity8", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RecipeViewModel", "MeasurementQuantity8");
            DropColumn("dbo.RecipeViewModel", "MeasurementType8");
            DropColumn("dbo.RecipeViewModel", "IngredientName8");
            DropColumn("dbo.RecipeViewModel", "MeasurementQuantity7");
            DropColumn("dbo.RecipeViewModel", "MeasurementType7");
            DropColumn("dbo.RecipeViewModel", "IngredientName7");
            DropColumn("dbo.RecipeViewModel", "MeasurementQuantity6");
            DropColumn("dbo.RecipeViewModel", "MeasurementType6");
            DropColumn("dbo.RecipeViewModel", "IngredientName6");
            DropColumn("dbo.RecipeViewModel", "MeasurementQuantity5");
            DropColumn("dbo.RecipeViewModel", "MeasurementType5");
            DropColumn("dbo.RecipeViewModel", "IngredientName5");
            DropColumn("dbo.RecipeViewModel", "MeasurementQuantity4");
            DropColumn("dbo.RecipeViewModel", "MeasurementType4");
            DropColumn("dbo.RecipeViewModel", "IngredientName4");
            DropColumn("dbo.RecipeViewModel", "MeasurementQuantity3");
            DropColumn("dbo.RecipeViewModel", "MeasurementType3");
            DropColumn("dbo.RecipeViewModel", "IngredientName3");
            DropColumn("dbo.RecipeViewModel", "MeasurementQuantity2");
            DropColumn("dbo.RecipeViewModel", "MeasurementType2");
            DropColumn("dbo.RecipeViewModel", "IngredientName2");
        }
    }
}
