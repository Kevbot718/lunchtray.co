namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MemberEvents", "Member_MemberID", "dbo.Members");
            DropForeignKey("dbo.MemberEvents", "Event_EventID", "dbo.Events");
            DropForeignKey("dbo.Events", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "AppUser_Id" });
            DropIndex("dbo.MemberEvents", new[] { "Member_MemberID" });
            DropIndex("dbo.MemberEvents", new[] { "Event_EventID" });
            CreateTable(
                "dbo.AppUserEvents",
                c => new
                    {
                        AppUser_Id = c.String(nullable: false, maxLength: 128),
                        Event_EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AppUser_Id, t.Event_EventID })
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_EventID, cascadeDelete: true)
                .Index(t => t.AppUser_Id)
                .Index(t => t.Event_EventID);
            
            AddColumn("dbo.Events", "Member_MemberID", c => c.Int());
            CreateIndex("dbo.Events", "Member_MemberID");
            AddForeignKey("dbo.Events", "Member_MemberID", "dbo.Members", "MemberID");
            DropColumn("dbo.Events", "AppUser_Id");
            DropTable("dbo.MemberEvents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MemberEvents",
                c => new
                    {
                        Member_MemberID = c.Int(nullable: false),
                        Event_EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Member_MemberID, t.Event_EventID });
            
            AddColumn("dbo.Events", "AppUser_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Events", "Member_MemberID", "dbo.Members");
            DropForeignKey("dbo.AppUserEvents", "Event_EventID", "dbo.Events");
            DropForeignKey("dbo.AppUserEvents", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AppUserEvents", new[] { "Event_EventID" });
            DropIndex("dbo.AppUserEvents", new[] { "AppUser_Id" });
            DropIndex("dbo.Events", new[] { "Member_MemberID" });
            DropColumn("dbo.Events", "Member_MemberID");
            DropTable("dbo.AppUserEvents");
            CreateIndex("dbo.MemberEvents", "Event_EventID");
            CreateIndex("dbo.MemberEvents", "Member_MemberID");
            CreateIndex("dbo.Events", "AppUser_Id");
            AddForeignKey("dbo.Events", "AppUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.MemberEvents", "Event_EventID", "dbo.Events", "EventID", cascadeDelete: true);
            AddForeignKey("dbo.MemberEvents", "Member_MemberID", "dbo.Members", "MemberID", cascadeDelete: true);
        }
    }
}
