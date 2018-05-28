using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.PlayerModels
{
    [Table("PLAYER_STATS")]
    public class PlayerStats
    {
        [Key, Column("ID")]
        public int Id { get; set; }

        #region Rating Stats

        [Required, Column("ACCELERATION"), Range(1, 100)]
        public int Acceleration { get; set; }

        [Required, Column("SPRINT_SPEED"), Range(1, 100)]
        public int SprintSpeed { get; set; }

        [Required, Column("SHOTS"), Range(1, 100)]
        public int Shots { get; set; }

        [Required, Column("LONG_SHOTS"), Range(1, 100)]
        public int LongShots { get; set; }

        [Required, Column("PENALTIES"), Range(1, 100)]
        public int Penalties { get; set; }

        [Required, Column("FREE_CICKS"), Range(1, 100)]
        public int FreeKicks { get; set; }

        [Required, Column("SHORT_PASSING"), Range(1, 100)]
        public int ShortPassing { get; set; }

        [Required, Column("LONG_PASSING"), Range(1, 100)]
        public int LongPassing { get; set; }

        [Required, Column("CROSSING"), Range(1, 100)]
        public int Crossing { get; set; }

        [Required, Column("AGILITY"), Range(1, 100)]
        public int Agility { get; set; }

        [Required, Column("BALL_CONTROL"), Range(1, 100)]
        public int BallControl { get; set; }

        [Required, Column("INTERCEPTIONS"), Range(1, 100)]
        public int Interceptions { get; set; }

        [Required, Column("HEADING"), Range(1, 100)]
        public int Heading { get; set; }

        [Required, Column("TACKLES"), Range(1, 100)]
        public int Tackles { get; set; }

        [Required, Column("STRENGTH"), Range(1, 100)]
        public int Strength { get; set; }

        [Required, Column("TALENT"), Range(1,5)]
        public int Talent { get; set; }

        #endregion

        [ForeignKey(nameof(Id))]
        public Player Player { get; set; }
    }
}
