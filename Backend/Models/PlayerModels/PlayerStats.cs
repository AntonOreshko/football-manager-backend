using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Backend.Builders;
using Backend.Enums;

namespace Backend.Models.PlayerModels
{
    [Table("PLAYER_STATS")]
    public class PlayerStats
    {
        [Key, Column("ID")]
        public int Id { get; set; }

        public List<PlayerStat> Stats { get; set; }

        public PlayerStats()
        {
            Stats = new List<PlayerStat>()
            {
                new PlayerStat(PlayerBuilder.ACCELERATION, StatsGroup.Speed, f => Acceleration = f, () => Acceleration),
                new PlayerStat(PlayerBuilder.SPRINT_SPEED, StatsGroup.Speed, f => SprintSpeed = f, () => SprintSpeed),

                new PlayerStat(PlayerBuilder.SHOTS, StatsGroup.Shooting, f => Shots = f, () => Shots),
                new PlayerStat(PlayerBuilder.LONG_SHOTS, StatsGroup.Shooting, f => LongShots = f, () => LongShots),
                new PlayerStat(PlayerBuilder.PENALTIES, StatsGroup.Shooting, f => Penalties = f, () => Penalties),
                new PlayerStat(PlayerBuilder.FREE_CICKS, StatsGroup.Shooting, f => FreeKicks = f, () => FreeKicks),

                new PlayerStat(PlayerBuilder.SHORT_PASSING, StatsGroup.Passing, f => ShortPassing = f, () => ShortPassing),
                new PlayerStat(PlayerBuilder.LONG_PASSING, StatsGroup.Passing, f => LongPassing = f, () => LongPassing),
                new PlayerStat(PlayerBuilder.CROSSING, StatsGroup.Passing, f => Crossing = f, () => Crossing),

                new PlayerStat(PlayerBuilder.AGILITY, StatsGroup.Technique, f => Agility = f, () => Agility),
                new PlayerStat(PlayerBuilder.BALL_CONTROL, StatsGroup.Technique, f => BallControl = f, () => BallControl),
                new PlayerStat(PlayerBuilder.TRICKS, StatsGroup.Technique, f => Tricks = f, () => Tricks),

                new PlayerStat(PlayerBuilder.INTERCEPTIONS, StatsGroup.Defending, f => Interceptions = f, () => Interceptions),
                new PlayerStat(PlayerBuilder.STANDING_TACKLES, StatsGroup.Defending, f => StandingTackles = f, () => StandingTackles),
                new PlayerStat(PlayerBuilder.SLIDING_TACKLES, StatsGroup.Defending, f => SlidingTackles = f, () => SlidingTackles),

                new PlayerStat(PlayerBuilder.JUMPING, StatsGroup.Physical, f => Jumping = f, () => Jumping),
                new PlayerStat(PlayerBuilder.STRENGTH, StatsGroup.Physical, f => Strength = f, () => Strength),
                new PlayerStat(PlayerBuilder.HEADING, StatsGroup.Physical, f => Heading = f, () => Heading),
                new PlayerStat(PlayerBuilder.STAMINA, StatsGroup.Physical, f => Stamina = f, () => Stamina),
            };
        }

        #region Rating Stats

        #region Speed

        [Required, Column("ACCELERATION")]
        public float Acceleration { get; set; }

        [Required, Column("SPRINT_SPEED")]
        public float SprintSpeed { get; set; }

        #endregion

        #region Shooting

        [Required, Column("SHOTS")]
        public float Shots { get; set; }

        [Required, Column("LONG_SHOTS")]
        public float LongShots { get; set; }

        [Required, Column("PENALTIES")]
        public float Penalties { get; set; }

        [Required, Column("FREE_CICKS")]
        public float FreeKicks { get; set; }

        #endregion

        #region Passing

        [Required, Column("SHORT_PASSING")]
        public float ShortPassing { get; set; }

        [Required, Column("LONG_PASSING")]
        public float LongPassing { get; set; }

        [Required, Column("CROSSING")]
        public float Crossing { get; set; }

        #endregion

        #region Technique

        [Required, Column("AGILITY")]
        public float Agility { get; set; }

        [Required, Column("BALL_CONTROL")]
        public float BallControl { get; set; }

        [Required, Column("TRICKS")]
        public float Tricks { get; set; }

        #endregion

        #region Defence

        [Required, Column("INTERCEPTIONS")]
        public float Interceptions { get; set; }

        [Required, Column("STANDING_TACKLES")]
        public float StandingTackles { get; set; }

        [Required, Column("SLIDING_TACKLES")]
        public float SlidingTackles { get; set; }

        #endregion

        #region Physical

        [Required, Column("JUMPING")]
        public float Jumping { get; set; }

        [Required, Column("STRENGTH")]
        public float Strength { get; set; }

        [Required, Column("HEADING")]
        public float Heading { get; set; }

        [Required, Column("STAMINA")]
        public float Stamina { get; set; }

        #endregion

        public void SetValue(string statName, float value)
        {
            var stat = Stats.FirstOrDefault(s => s.Name == statName);
            if (stat != null) stat.Value = value;
            else throw new Exception("Stat \"" + statName + "\" not found!");
        }

        public float GetValue(string statName)
        {
            var stat = Stats.FirstOrDefault(s => s.Name == statName);
            if (stat != null) return stat.Value;
            throw new Exception("Stat \"" + statName + "\" not found!");
        }

        [Required, Column("TALENT")]
        public float Talent { get; set; }

        #endregion

        [ForeignKey(nameof(Id))]
        public Player Player { get; set; }
    }
}
