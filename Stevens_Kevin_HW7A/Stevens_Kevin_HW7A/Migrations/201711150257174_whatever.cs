namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatever : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecipeViewModels", "InstructionText", c => c.Int(nullable: false));
            DropColumn("dbo.RecipeViewModels", "InstructionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RecipeViewModels", "InstructionID", c => c.Int(nullable: false));
            DropColumn("dbo.RecipeViewModels", "InstructionText");
        }
    }
}
