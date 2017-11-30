namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedrecipedatabase : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Recipe", "PrepTime");
            DropColumn("dbo.Recipe", "CookTime");
            DropColumn("dbo.Recipe", "TotalCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipe", "TotalCost", c => c.Double(nullable: false));
            AddColumn("dbo.Recipe", "CookTime", c => c.Int(nullable: false));
            AddColumn("dbo.Recipe", "PrepTime", c => c.Int(nullable: false));
        }
    }
}
