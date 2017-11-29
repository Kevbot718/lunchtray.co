namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedRecipefromDAteTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Dates", "RecipeViewModelID");
            DropColumn("dbo.Dates", "RecipeName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dates", "RecipeName", c => c.String());
            AddColumn("dbo.Dates", "RecipeViewModelID", c => c.Int(nullable: false));
        }
    }
}
