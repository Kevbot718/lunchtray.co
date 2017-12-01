namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4models : DbMigration
    {
        public override void Up()
        {

            RenameTable(name: "dbo.Order", newName: "Orders");

            DropForeignKey("dbo.Recipe", "Order_OrderID", "dbo.Order");


            DropIndex("dbo.Recipe", new[] { "Order_OrderID" });

            CreateTable(
                "dbo.DayConfigs",
                c => new
                    {
                        Date = c.DateTime(nullable: false),
                        MenuType = c.Int(nullable: false),
                        RecipeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Date)
                .ForeignKey("dbo.Recipe", t => t.RecipeID, cascadeDelete: true)
                .Index(t => t.RecipeID);
            
            CreateTable(
                "dbo.CustomerOrderBridges",
                c => new
                    {
                        CustomerID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerID, t.OrderID })
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        SchoolName = c.String(),
                        Default = c.Int(nullable: false),
                        Nickname = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            AddColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "PortionSize", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Date");
            AddForeignKey("dbo.Orders", "Date", "dbo.DayConfigs", "Date", cascadeDelete: true);

            DropColumn("dbo.Recipe", "Order_OrderID");
            DropColumn("dbo.Orders", "ServingSize");
            DropColumn("dbo.Orders", "Monday");
            DropColumn("dbo.Orders", "Tuesday");
            DropColumn("dbo.Orders", "Wednesday");
            DropColumn("dbo.Orders", "Thursday");
            DropColumn("dbo.Orders", "Friday");
  
        }
        
        public override void Down()
        {

            AddColumn("dbo.Orders", "Friday", c => c.String());
            AddColumn("dbo.Orders", "Thursday", c => c.String());
            AddColumn("dbo.Orders", "Wednesday", c => c.String());
            AddColumn("dbo.Orders", "Tuesday", c => c.String());
            AddColumn("dbo.Orders", "Monday", c => c.String());
            AddColumn("dbo.Orders", "ServingSize", c => c.String());
            AddColumn("dbo.Recipe", "Order_OrderID", c => c.Int());

            DropForeignKey("dbo.DayConfigs", "RecipeID", "dbo.Recipe");
            DropForeignKey("dbo.Orders", "Date", "dbo.DayConfigs");
            DropForeignKey("dbo.CustomerOrderBridges", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.CustomerOrderBridges", "CustomerID", "dbo.Customers");
            DropIndex("dbo.CustomerOrderBridges", new[] { "OrderID" });
            DropIndex("dbo.CustomerOrderBridges", new[] { "CustomerID" });
            DropIndex("dbo.Orders", new[] { "Date" });
            DropIndex("dbo.DayConfigs", new[] { "RecipeID" });
            DropColumn("dbo.Orders", "PortionSize");
            DropColumn("dbo.Orders", "Type");
            DropColumn("dbo.Orders", "Date");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerOrderBridges");
            DropTable("dbo.DayConfigs");

            CreateIndex("dbo.Recipe", "Order_OrderID");


            AddForeignKey("dbo.Recipe", "Order_OrderID", "dbo.Order", "OrderID");

            RenameTable(name: "dbo.Orders", newName: "Order");
            RenameTable(name: "dbo.Ingredients", newName: "Ingredient");
        }
    }
}
