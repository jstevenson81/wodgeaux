namespace wodgeaux.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserMovements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkoutId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workout", t => t.WorkoutId, cascadeDelete: true)
                .Index(t => t.WorkoutId);
            
            CreateTable(
                "dbo.Workout",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMovements", "WorkoutId", "dbo.Workout");
            DropIndex("dbo.UserMovements", new[] { "WorkoutId" });
            DropTable("dbo.Workout");
            DropTable("dbo.UserMovements");
        }
    }
}
