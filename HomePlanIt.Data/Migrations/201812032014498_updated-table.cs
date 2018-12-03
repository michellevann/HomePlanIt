namespace HomePlanIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedtable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Supply", "SupplyName", c => c.String());
            AlterColumn("dbo.Roadblock", "RoadblockName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roadblock", "RoadblockName", c => c.String(nullable: false));
            AlterColumn("dbo.Supply", "SupplyName", c => c.String(nullable: false));
        }
    }
}
