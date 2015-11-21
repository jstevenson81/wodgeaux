using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace wodgeaux.web.Models
{
    [Table("Workout")]
    public class Workout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("WorkoutDate")]
        public DateTime? WorkoutDate { get; set; }

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

    public class Context : DbContext
    {
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<UserMovement> UserMovements { get; set; } 
    }
}