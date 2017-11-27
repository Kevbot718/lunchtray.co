namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipe", "RecipeViewModel_RecipeViewModelID", c => c.Int());
            CreateIndex("dbo.Recipe", "RecipeViewModel_RecipeViewModelID");
            AddForeignKey("dbo.Recipe", "RecipeViewModel_RecipeViewModelID", "dbo.RecipeViewModels", "RecipeViewModelID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipe", "RecipeViewModel_RecipeViewModelID", "dbo.RecipeViewModels");
            DropIndex("dbo.Recipe", new[] { "RecipeViewModel_RecipeViewModelID" });
            DropColumn("dbo.Recipe", "RecipeViewModel_RecipeViewModelID");
        }
    }
}
