namespace MacroTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodMacroDecimals : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Food", "Proteins", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Food", "Fats", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Food", "Carbs", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Food", "Carbs", c => c.Int(nullable: false));
            AlterColumn("dbo.Food", "Fats", c => c.Int(nullable: false));
            AlterColumn("dbo.Food", "Proteins", c => c.Int(nullable: false));
        }
    }
}
