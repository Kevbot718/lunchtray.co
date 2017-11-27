namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedModels1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "OKToText");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "OKToText", c => c.Boolean(nullable: false));
        }
    }
}
