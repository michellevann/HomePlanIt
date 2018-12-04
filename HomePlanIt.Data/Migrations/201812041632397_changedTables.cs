namespace HomePlanIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedTables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Supply", "SupplyName", c => c.String(nullable: false));
            AlterColumn("dbo.Roadblock", "RoadblockName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roadblock", "RoadblockName", c => c.String());
            AlterColumn("dbo.Supply", "SupplyName", c => c.String());
        }
    }
}
