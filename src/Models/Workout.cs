using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

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
        [MaxLength(255)]
        public string Name { get; set; }
        public List<WorkoutMovement> WorkoutMovements { get; set; }
    }

    public class WorkoutMovement : EntityBase
    {
        [Required]
        public int Repetitions { get; set; }

        [Required]
        public int MovementMeasurementId { get; set; }

        [ForeignKey("MovementMeasurementId")]
        public MovementMeasurement MovementMeasurement { get; set; }

        [Required]
        public int WorkoutId { get; set; }

        [ForeignKey("WorkoutId")]
        public Workout Workout { get; set; }

    }

    public class MovementType : EntityBase
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public List<Movement> Movements { get; set; }
    }

    public class UnitOfMeasure : EntityBase
    {
        [Required]
        [MaxLength(255)]
        public string System { get; set; }

        public List<MovementMeasurement> MovementWeights { get; set; }
    }

    public class MovementMeasurement : EntityBase
    {
        [Required]
        public double Measurement { get; set; }

        [Required]
        public int UnitOfMeasureId { get; set; }

        [ForeignKey("UnitOfMeasureId")]
        public UnitOfMeasure UnitOfMeasure { get; set; }

        [Required]
        public int MovementId { get; set; }

        [ForeignKey("MovementId")]
        public Movement Movement { get; set; }

        public List<UserMovement> UserMovements { get; set; }
        public List<WorkoutMovement> WorkoutMovements { get; set; }
    }

    public class Movement : EntityBase
    {
        [Required]
        public int MovementTypeId { get; set; }

        [ForeignKey("MovementTypeId")]
        public MovementType MovementType { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Standard { get; set; }

        [Required]
        [MaxLength(255)]
        public string StandardVideoUrl { get; set; }
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
        public int UserWorkoutId { get; set; }

        [ForeignKey("UserWorkoutId")]
        public UserWorkout Workout { get; set; }

        [Required]
        public int MovementMeasurementId { get; set; }

        [ForeignKey("MovementMeasurementId")]
        public MovementMeasurement MovementMeasurement { get; set; }
    }

    public class WodgeauxContext : DbContext
    {
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutMovement> WorkoutMovements { get; set; }
        public DbSet<MovementType> MovementTypes { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public DbSet<MovementMeasurement> MovementMeasurements { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<UserWorkout> UserWorkouts { get; set; }
        public DbSet<UserMovement> UserMovements { get; set; }
    }
}