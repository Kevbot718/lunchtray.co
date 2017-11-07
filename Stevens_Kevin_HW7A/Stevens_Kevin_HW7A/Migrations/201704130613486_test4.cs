namespace Stevens_Kevin_HW7A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Member_MemberID", "dbo.Members");
            DropIndex("dbo.Events", new[] { "Member_MemberID" });
            DropColumn("dbo.Events", "Member_MemberID");
            DropTable("dbo.Members");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Events", "Member_MemberID", c => c.Int());
            CreateIndex("dbo.Events", "Member_MemberID");
            AddForeignKey("dbo.Events", "Member_MemberID", "dbo.Members", "MemberID");
        }
    }
}
