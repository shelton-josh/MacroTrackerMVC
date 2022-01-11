namespace MacroTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodGuid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Food", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Food", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Food", "Content");
            DropColumn("dbo.Food", "OwnerId");
        }
    }
}
