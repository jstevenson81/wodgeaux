using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace wodgeaux.web.Models
{
    public abstract class EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }


    public class Workout : EntityBase
    {
        public string Name { get; set; }
        public List<WorkoutMovement> WorkoutMovements { get; set; }
    }

    public class WorkoutMovement : EntityBase
    {
        public int MovementId { get; set; }

        [ForeignKey("MovementId")]
        public Movement Movement { get; set; }

        public int WorkoutId { get; set; }

        [ForeignKey("WorkoutId")]
        public Workout Workout { get; set; }

    }

    /// <summary>
    /// The type of movement:
    /// Gymnastics Movement
    /// Running
    /// Press
    /// Clean
    /// Snatch
    /// </summary>
    public class MovementType : EntityBase
    {

        public string Name { get; set; }

        public List<Movement> Movements { get; set; }
    }

    /// <summary>
    /// The movement
    /// </summary>
    public class Movement : EntityBase
    {
        /// <summary>
        /// The foreign key to movement type
        /// </summary>
        [Required]
        public int MovementTypeId { get; set; }

        /// <summary>
        /// The movement's movement type
        /// </summary>
        [ForeignKey("MovementTypeId")]
        public MovementType MovementType { get; set; }

        /// <summary>
        /// The name of the movements
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The movement standard as described in text
        /// </summary>
        public string Standard { get; set; }

        /// <summary>
        /// A URL to the standard video
        /// </summary>
        public string StandardVideoUrl { get; set; }

        /// <summary>
        /// The collection of workouts this movement belongs to.  It is a many to many
        /// because one movement can be associated to more than one workout and more than
        /// one workout can be associated to a movement.
        /// </summary>
        public List<WorkoutMovement> WorkoutMovements { get; set; }

    }

    public class UserWorkout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime? WorkoutDateTime { get; set; }
        

        public List<UserMovement> MyMovements { get; set; }
    }

    public class UserMovement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int WorkoutId { get; set; }

        [ForeignKey("WorkoutId")]
        public Workout Workout { get; set; }
    }

    public class WodgeauxContext : DbContext
    {
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<UserMovement> UserMovements { get; set; } 
    }
}