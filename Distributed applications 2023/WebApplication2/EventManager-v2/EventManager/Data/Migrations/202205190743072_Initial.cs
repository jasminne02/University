namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(),
                        Duration = c.Int(nullable: false),
                        HomeTeamID = c.Int(),
                        HomeScore = c.Int(nullable: false),
                        AwayTeamID = c.Int(),
                        AwayScore = c.Int(nullable: false),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedAt = c.DateTime(),
                        Team_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teams", t => t.Team_ID)
                .ForeignKey("dbo.Teams", t => t.AwayTeamID)
                .ForeignKey("dbo.Teams", t => t.HomeTeamID)
                .Index(t => t.HomeTeamID)
                .Index(t => t.AwayTeamID)
                .Index(t => t.Team_ID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Country = c.String(),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Names = c.String(),
                        Age = c.Int(),
                        TeamID = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teams", t => t.TeamID)
                .Index(t => t.TeamID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "HomeTeamID", "dbo.Teams");
            DropForeignKey("dbo.Events", "AwayTeamID", "dbo.Teams");
            DropForeignKey("dbo.Players", "TeamID", "dbo.Teams");
            DropForeignKey("dbo.Events", "Team_ID", "dbo.Teams");
            DropIndex("dbo.Players", new[] { "TeamID" });
            DropIndex("dbo.Events", new[] { "Team_ID" });
            DropIndex("dbo.Events", new[] { "AwayTeamID" });
            DropIndex("dbo.Events", new[] { "HomeTeamID" });
            DropTable("dbo.Players");
            DropTable("dbo.Teams");
            DropTable("dbo.Events");
        }
    }
}
