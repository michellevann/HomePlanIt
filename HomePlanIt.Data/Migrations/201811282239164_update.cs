namespace HomePlanIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsBought = c.Boolean(nullable: false),
                        DIYId = c.Int(nullable: false),
                        DIY_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.DIY", t => t.DIY_ProjectId)
                .Index(t => t.DIY_ProjectId);
            
            CreateTable(
                "dbo.Roadblock",
                c => new
                    {
                        RoadblockId = c.Int(nullable: false, identity: true),
                        RoadblockName = c.String(nullable: false),
                        IsComplete = c.Boolean(nullable: false),
                        Note = c.String(),
                        DIYId = c.Int(nullable: false),
                        DIY_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.RoadblockId)
                .ForeignKey("dbo.DIY", t => t.DIY_ProjectId)
                .Index(t => t.DIY_ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roadblock", "DIY_ProjectId", "dbo.DIY");
            DropForeignKey("dbo.Item", "DIY_ProjectId", "dbo.DIY");
            DropIndex("dbo.Roadblock", new[] { "DIY_ProjectId" });
            DropIndex("dbo.Item", new[] { "DIY_ProjectId" });
            DropTable("dbo.Roadblock");
            DropTable("dbo.Item");
        }
    }
}
