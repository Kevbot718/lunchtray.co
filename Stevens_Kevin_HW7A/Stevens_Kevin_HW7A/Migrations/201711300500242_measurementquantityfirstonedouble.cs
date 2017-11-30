namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class measurementquantityfirstonedouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RecipeIngredientBridges", "MeasurementQuantity", c => c.Double(nullable: false));
            AlterColumn("dbo.RecipeViewModel", "MeasurementQuantity", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RecipeViewModel", "MeasurementQuantity", c => c.Int(nullable: false));
            AlterColumn("dbo.RecipeIngredientBridges", "MeasurementQuantity", c => c.Int(nullable: false));
        }
    }
}
