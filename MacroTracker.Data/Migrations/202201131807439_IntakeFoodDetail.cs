namespace MacroTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntakeFoodDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Intake", "FoodDetail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Intake", "FoodDetail");
        }
    }
}
