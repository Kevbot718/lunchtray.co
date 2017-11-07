namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Committee_CommitteeID", "dbo.Committees");
            DropForeignKey("dbo.AppUserEvents", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AppUserEvents", "Event_EventID", "dbo.Events");
            DropIndex("dbo.Events", new[] { "Committee_CommitteeID" });
            DropIndex("dbo.AppUserEvents", new[] { "AppUser_Id" });
            DropIndex("dbo.AppUserEvents", new[] { "Event_EventID" });
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        IngredientID = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(),
                        Order_OrderID = c.Int(),
                        Subscription_SubscriptionID = c.Int(),
                    })
                .PrimaryKey(t => t.IngredientID)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID)
                .ForeignKey("dbo.Subscriptions", t => t.Subscription_SubscriptionID)
                .Index(t => t.Order_OrderID)
                .Index(t => t.Subscription_SubscriptionID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        ServingSize = c.String(),
                        Monday = c.String(),
                        Tuesday = c.String(),
                        Wednesday = c.String(),
                        Thursday = c.String(),
                        Friday = c.String(),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        RecipeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Ingredient = c.String(),
                        Ingredient2 = c.String(),
                        Ingredient3 = c.String(),
                        WorkInstructions = c.String(),
                    })
                .PrimaryKey(t => t.RecipeID);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        SubscriptionID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Meals = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubscriptionID);
            
            CreateTable(
                "dbo.RecipeIngredients",
                c => new
                    {
                        Recipe_RecipeID = c.Int(nullable: false),
                        Ingredient_IngredientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_RecipeID, t.Ingredient_IngredientID })
                .ForeignKey("dbo.Recipes", t => t.Recipe_RecipeID, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_IngredientID, cascadeDelete: true)
                .Index(t => t.Recipe_RecipeID)
                .Index(t => t.Ingredient_IngredientID);
            
            DropTable("dbo.Committees");
            DropTable("dbo.Events");
            DropTable("dbo.AppUserEvents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AppUserEvents",
                c => new
                    {
                        AppUser_Id = c.String(nullable: false, maxLength: 128),
                        Event_EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AppUser_Id, t.Event_EventID });
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        EventTitle = c.String(nullable: false),
                        EventDate = c.DateTime(nullable: false),
                        EventLocation = c.String(nullable: false),
                        MembersOnly = c.Boolean(nullable: false),
                        Committee_CommitteeID = c.Int(),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.Committees",
                c => new
                    {
                        CommitteeID = c.Int(nullable: false, identity: true),
                        CommitteeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CommitteeID);
            
            DropForeignKey("dbo.Ingredients", "Subscription_SubscriptionID", "dbo.Subscriptions");
            DropForeignKey("dbo.RecipeIngredients", "Ingredient_IngredientID", "dbo.Ingredients");
            DropForeignKey("dbo.RecipeIngredients", "Recipe_RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.Ingredients", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.RecipeIngredients", new[] { "Ingredient_IngredientID" });
            DropIndex("dbo.RecipeIngredients", new[] { "Recipe_RecipeID" });
            DropIndex("dbo.Ingredients", new[] { "Subscription_SubscriptionID" });
            DropIndex("dbo.Ingredients", new[] { "Order_OrderID" });
            DropTable("dbo.RecipeIngredients");
            DropTable("dbo.Subscriptions");
            DropTable("dbo.Recipes");
            DropTable("dbo.Orders");
            DropTable("dbo.Ingredients");
            CreateIndex("dbo.AppUserEvents", "Event_EventID");
            CreateIndex("dbo.AppUserEvents", "AppUser_Id");
            CreateIndex("dbo.Events", "Committee_CommitteeID");
            AddForeignKey("dbo.AppUserEvents", "Event_EventID", "dbo.Events", "EventID", cascadeDelete: true);
            AddForeignKey("dbo.AppUserEvents", "AppUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Events", "Committee_CommitteeID", "dbo.Committees", "CommitteeID");
        }
    }
}
