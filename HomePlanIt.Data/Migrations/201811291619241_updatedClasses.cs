namespace HomePlanIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedClasses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Item", "DIY_ProjectId", "dbo.DIY");
            DropIndex("dbo.Item", new[] { "DIY_ProjectId" });
            CreateTable(
                "dbo.Supply",
                c => new
                    {
                        SupplyId = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Color = c.String(),
                        Quantity = c.Int(nullable: false),
                        SupplyName = c.String(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AlreadyHave = c.Boolean(nullable: false),
                        DIYId = c.Int(nullable: false),
                        DIY_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.SupplyId)
                .ForeignKey("dbo.DIY", t => t.DIY_ProjectId)
                .Index(t => t.DIY_ProjectId);
            
            AddColumn("dbo.DIY", "BudgetedAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DIY", "FinalCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Roadblock", "Plan", c => c.String());
            AlterColumn("dbo.DIY", "StartDate", c => c.DateTime());
            AlterColumn("dbo.DIY", "EndDate", c => c.DateTime());
            DropColumn("dbo.DIY", "TotalCost");
            DropColumn("dbo.Roadblock", "Note");
            DropTable("dbo.Item");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.ItemId);
            
            AddColumn("dbo.Roadblock", "Note", c => c.String());
            AddColumn("dbo.DIY", "TotalCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Supply", "DIY_ProjectId", "dbo.DIY");
            DropIndex("dbo.Supply", new[] { "DIY_ProjectId" });
            AlterColumn("dbo.DIY", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DIY", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Roadblock", "Plan");
            DropColumn("dbo.DIY", "FinalCost");
            DropColumn("dbo.DIY", "BudgetedAmount");
            DropTable("dbo.Supply");
            CreateIndex("dbo.Item", "DIY_ProjectId");
            AddForeignKey("dbo.Item", "DIY_ProjectId", "dbo.DIY", "ProjectId");
        }
    }
}
