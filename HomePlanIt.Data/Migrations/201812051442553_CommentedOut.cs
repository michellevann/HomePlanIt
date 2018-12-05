namespace HomePlanIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentedOut : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Roadblock", "DIYId", "dbo.DIY");
            DropIndex("dbo.Roadblock", new[] { "DIYId" });
            DropColumn("dbo.Roadblock", "DIYId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roadblock", "DIYId", c => c.Int(nullable: false));
            CreateIndex("dbo.Roadblock", "DIYId");
            AddForeignKey("dbo.Roadblock", "DIYId", "dbo.DIY", "DIYId", cascadeDelete: true);
        }
    }
}
