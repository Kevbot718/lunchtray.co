namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recipeviewmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeViewModels",
                c => new
                    {
                        RecipeViewModelID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.RecipeViewModelID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RecipeViewModels");
        }
    }
}
