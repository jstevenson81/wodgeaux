namespace wodgeaux.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompleteMovementSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovementMeasurements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Measurement = c.Double(nullable: false),
                        UnitOfMeasureId = c.Int(nullable: false),
                        MovementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movements", t => t.MovementId, cascadeDelete: true)
                .ForeignKey("dbo.UnitOfMeasures", t => t.UnitOfMeasureId, cascadeDelete: true)
                .Index(t => t.UnitOfMeasureId)
                .Index(t => t.MovementId);
            
            CreateTable(
                "dbo.Movements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovementTypeId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Standard = c.String(nullable: false, maxLength: 255),
                        StandardVideoUrl = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovementTypes", t => t.MovementTypeId, cascadeDelete: true)
                .Index(t => t.MovementTypeId);
            
            CreateTable(
                "dbo.MovementTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UnitOfMeasures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        System = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserMovements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserWorkoutId = c.Int(nullable: false),
                        MovementMeasurementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovementMeasurements", t => t.MovementMeasurementId, cascadeDelete: true)
                .ForeignKey("dbo.UserWorkouts", t => t.UserWorkoutId, cascadeDelete: true)
                .Index(t => t.UserWorkoutId)
                .Index(t => t.MovementMeasurementId);
            
            CreateTable(
                "dbo.UserWorkouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkoutDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkoutMovements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Repetitions = c.Int(nullable: false),
                        MovementMeasurementId = c.Int(nullable: false),
                        WorkoutId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovementMeasurements", t => t.MovementMeasurementId, cascadeDelete: true)
                .ForeignKey("dbo.Workouts", t => t.WorkoutId, cascadeDelete: true)
                .Index(t => t.MovementMeasurementId)
                .Index(t => t.WorkoutId);
            
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkoutMovements", "WorkoutId", "dbo.Workouts");
            DropForeignKey("dbo.WorkoutMovements", "MovementMeasurementId", "dbo.MovementMeasurements");
            DropForeignKey("dbo.UserMovements", "UserWorkoutId", "dbo.UserWorkouts");
            DropForeignKey("dbo.UserMovements", "MovementMeasurementId", "dbo.MovementMeasurements");
            DropForeignKey("dbo.MovementMeasurements", "UnitOfMeasureId", "dbo.UnitOfMeasures");
            DropForeignKey("dbo.MovementMeasurements", "MovementId", "dbo.Movements");
            DropForeignKey("dbo.Movements", "MovementTypeId", "dbo.MovementTypes");
            DropIndex("dbo.WorkoutMovements", new[] { "WorkoutId" });
            DropIndex("dbo.WorkoutMovements", new[] { "MovementMeasurementId" });
            DropIndex("dbo.UserMovements", new[] { "MovementMeasurementId" });
            DropIndex("dbo.UserMovements", new[] { "UserWorkoutId" });
            DropIndex("dbo.Movements", new[] { "MovementTypeId" });
            DropIndex("dbo.MovementMeasurements", new[] { "MovementId" });
            DropIndex("dbo.MovementMeasurements", new[] { "UnitOfMeasureId" });
            DropTable("dbo.Workouts");
            DropTable("dbo.WorkoutMovements");
            DropTable("dbo.UserWorkouts");
            DropTable("dbo.UserMovements");
            DropTable("dbo.UnitOfMeasures");
            DropTable("dbo.MovementTypes");
            DropTable("dbo.Movements");
            DropTable("dbo.MovementMeasurements");
        }
    }
}
