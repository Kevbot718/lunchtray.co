namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Committees",
                c => new
                    {
                        CommitteeID = c.Int(nullable: false, identity: true),
                        CommitteeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CommitteeID);
            
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
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Committees", t => t.Committee_CommitteeID)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id)
                .Index(t => t.Committee_CommitteeID)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        OKToText = c.Boolean(nullable: false),
                        Majors = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemberID);
            
            CreateTable(
                "dbo.MemberEvents",
                c => new
                    {
                        Member_MemberID = c.Int(nullable: false),
                        Event_EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Member_MemberID, t.Event_EventID })
                .ForeignKey("dbo.Members", t => t.Member_MemberID, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_EventID, cascadeDelete: true)
                .Index(t => t.Member_MemberID)
                .Index(t => t.Event_EventID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.MemberEvents", "Event_EventID", "dbo.Events");
            DropForeignKey("dbo.MemberEvents", "Member_MemberID", "dbo.Members");
            DropForeignKey("dbo.Events", "Committee_CommitteeID", "dbo.Committees");
            DropIndex("dbo.MemberEvents", new[] { "Event_EventID" });
            DropIndex("dbo.MemberEvents", new[] { "Member_MemberID" });
            DropIndex("dbo.Events", new[] { "AppUser_Id" });
            DropIndex("dbo.Events", new[] { "Committee_CommitteeID" });
            DropTable("dbo.MemberEvents");
            DropTable("dbo.Members");
            DropTable("dbo.Events");
            DropTable("dbo.Committees");
        }
    }
}
