namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class instruction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instructions",
                c => new
                    {
                        InstructionID = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        Number = c.String(),
                        InstructionText = c.String(),
                    })
                .PrimaryKey(t => t.InstructionID)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instructions", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.Instructions", new[] { "RecipeId" });
            DropTable("dbo.Instructions");
        }
    }
}
