namespace MacroTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intake : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Intake",
                c => new
                    {
                        IntakeId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FoodId = c.Int(nullable: false),
                        IntakeName = c.String(nullable: false),
                        FoodQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IntakeId)
                .ForeignKey("dbo.Food", t => t.FoodId, cascadeDelete: true)
                .Index(t => t.FoodId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Intake", "FoodId", "dbo.Food");
            DropIndex("dbo.Intake", new[] { "FoodId" });
            DropTable("dbo.Intake");
        }
    }
}
