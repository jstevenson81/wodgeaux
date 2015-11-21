namespace wodgeaux.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingWorkoutDatetoWorkouttable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workout", "WorkoutDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workout", "WorkoutDate");
        }
    }
}
