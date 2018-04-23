namespace PG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFacility : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Location = c.Geography(),
                        SiteId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: true)
                .Index(t => t.SiteId);
            
            AddColumn("dbo.Sites", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facilities", "SiteId", "dbo.Sites");
            DropIndex("dbo.Facilities", new[] { "SiteId" });
            DropColumn("dbo.Sites", "Type");
            DropTable("dbo.Facilities");
        }
    }
}
