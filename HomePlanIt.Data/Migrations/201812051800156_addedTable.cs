namespace HomePlanIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FullProject",
                c => new
                    {
                        FullProjectId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        DIYId = c.Int(nullable: false),
                        SupplyId = c.Int(nullable: false),
                        RoadblockId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FullProjectId)
                .ForeignKey("dbo.DIY", t => t.DIYId, cascadeDelete: true)
                .ForeignKey("dbo.Roadblock", t => t.RoadblockId, cascadeDelete: true)
                .ForeignKey("dbo.Supply", t => t.SupplyId, cascadeDelete: true)
                .Index(t => t.DIYId)
                .Index(t => t.SupplyId)
                .Index(t => t.RoadblockId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FullProject", "SupplyId", "dbo.Supply");
            DropForeignKey("dbo.FullProject", "RoadblockId", "dbo.Roadblock");
            DropForeignKey("dbo.FullProject", "DIYId", "dbo.DIY");
            DropIndex("dbo.FullProject", new[] { "RoadblockId" });
            DropIndex("dbo.FullProject", new[] { "SupplyId" });
            DropIndex("dbo.FullProject", new[] { "DIYId" });
            DropTable("dbo.FullProject");
        }
    }
}
