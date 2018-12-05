namespace HomePlanIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDIYId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Supply", "DIYId", "dbo.DIY");
            DropIndex("dbo.Supply", new[] { "DIYId" });
            DropColumn("dbo.Supply", "DIYId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Supply", "DIYId", c => c.Int(nullable: false));
            CreateIndex("dbo.Supply", "DIYId");
            AddForeignKey("dbo.Supply", "DIYId", "dbo.DIY", "DIYId", cascadeDelete: true);
        }
    }
}
