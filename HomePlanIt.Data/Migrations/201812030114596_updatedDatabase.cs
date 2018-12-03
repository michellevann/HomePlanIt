namespace HomePlanIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Supply", "DIY_ProjectId", "dbo.DIY");
            DropForeignKey("dbo.Roadblock", "DIY_ProjectId", "dbo.DIY");
            DropForeignKey("dbo.Supply", "DIYId", "dbo.DIY");
            DropForeignKey("dbo.Roadblock", "DIYId", "dbo.DIY");
            DropIndex("dbo.Supply", new[] { "DIY_ProjectId" });
            DropIndex("dbo.Roadblock", new[] { "DIY_ProjectId" });
            DropColumn("dbo.Supply", "DIYId");
            DropColumn("dbo.Roadblock", "DIYId");
            RenameColumn(table: "dbo.Supply", name: "DIY_ProjectId", newName: "DIYId");
            RenameColumn(table: "dbo.Roadblock", name: "DIY_ProjectId", newName: "DIYId");
            DropPrimaryKey("dbo.DIY");
            AddColumn("dbo.DIY", "DIYId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Supply", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Supply", "TotalCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Roadblock", "OwnerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Supply", "DIYId", c => c.Int(nullable: false));
            AlterColumn("dbo.Roadblock", "DIYId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.DIY", "DIYId");
            CreateIndex("dbo.Supply", "DIYId");
            CreateIndex("dbo.Roadblock", "DIYId");
            AddForeignKey("dbo.Supply", "DIYId", "dbo.DIY", "DIYId", cascadeDelete: true);
            AddForeignKey("dbo.Roadblock", "DIYId", "dbo.DIY", "DIYId", cascadeDelete: true);
            DropColumn("dbo.DIY", "ProjectId");
            DropColumn("dbo.Supply", "Cost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Supply", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DIY", "ProjectId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Roadblock", "DIYId", "dbo.DIY");
            DropForeignKey("dbo.Supply", "DIYId", "dbo.DIY");
            DropIndex("dbo.Roadblock", new[] { "DIYId" });
            DropIndex("dbo.Supply", new[] { "DIYId" });
            DropPrimaryKey("dbo.DIY");
            AlterColumn("dbo.Roadblock", "DIYId", c => c.Int());
            AlterColumn("dbo.Supply", "DIYId", c => c.Int());
            DropColumn("dbo.Roadblock", "OwnerId");
            DropColumn("dbo.Supply", "TotalCost");
            DropColumn("dbo.Supply", "OwnerId");
            DropColumn("dbo.DIY", "DIYId");
            AddPrimaryKey("dbo.DIY", "ProjectId");
            RenameColumn(table: "dbo.Roadblock", name: "DIYId", newName: "DIY_ProjectId");
            RenameColumn(table: "dbo.Supply", name: "DIYId", newName: "DIY_ProjectId");
            AddColumn("dbo.Roadblock", "DIYId", c => c.Int(nullable: false));
            AddColumn("dbo.Supply", "DIYId", c => c.Int(nullable: false));
            CreateIndex("dbo.Roadblock", "DIY_ProjectId");
            CreateIndex("dbo.Supply", "DIY_ProjectId");
            AddForeignKey("dbo.Roadblock", "DIYId", "dbo.DIY", "DIYId", cascadeDelete: true);
            AddForeignKey("dbo.Supply", "DIYId", "dbo.DIY", "DIYId", cascadeDelete: true);
            AddForeignKey("dbo.Roadblock", "DIY_ProjectId", "dbo.DIY", "ProjectId");
            AddForeignKey("dbo.Supply", "DIY_ProjectId", "dbo.DIY", "ProjectId");
        }
    }
}
