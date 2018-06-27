using BusinessLayer.Data;
using DomainModels.Models.PlayerEntities;

namespace WebApi.ViewModels
{
    public class PlayerStatsViewModel
    {
        public float OverallRating { get; set; }

        public float Speed { get; set; }

        public float Shooting { get; set; }

        public float Passing { get; set; }

        public float Technique { get; set; }

        public float Defending { get; set; }

        public float Physical { get; set; }

        public float Goalkeeping { get; set; }

        public float Acceleration { get; set; }

        public float SprintSpeed { get; set; }

        public float Shots { get; set; }

        public float LongShots { get; set; }

        public float Penalties { get; set; }

        public float FreeKicks { get; set; }

        public float ShortPassing { get; set; }

        public float LongPassing { get; set; }

        public float Crossing { get; set; }

        public float Agility { get; set; }

        public float BallControl { get; set; }

        public float Tricks { get; set; }

        public float Interceptions { get; set; }

        public float StandingTackles { get; set; }

        public float SlidingTackles { get; set; }

        public float Jumping { get; set; }

        public float Strength { get; set; }

        public float Heading { get; set; }

        public float Stamina { get; set; }

        public float HandPlay { get; set; }

        public float Kicking { get; set; }

        public float Reflexes { get; set; }

        public float Positioning { get; set; }

        public static PlayerStatsViewModel Get(PlayerStats stats)
        {
            var statsWrapper = new PlayerStatsWrapper(stats);



            return new PlayerStatsViewModel
            {
                Acceleration = stats.Acceleration,
                SprintSpeed = stats.SprintSpeed,
                Shots = stats.Shots,
                LongShots = stats.LongShots,
                Penalties = stats.Penalties,
                FreeKicks = stats.FreeKicks,
                ShortPassing = stats.ShortPassing,
                LongPassing = stats.LongPassing,
                Crossing = stats.Crossing,
                Agility = stats.Agility,
                BallControl = stats.BallControl,
                Tricks = stats.Tricks,
                Interceptions = stats.Interceptions,
                StandingTackles = stats.StandingTackles,
                SlidingTackles = stats.SlidingTackles,
                Jumping = stats.Jumping,
                Strength = stats.Strength,
                Heading = stats.Heading,
                Stamina = stats.Stamina,
                HandPlay = stats.HandPlay,
                Kicking = stats.Kicking,
                Reflexes = stats.Reflexes,
                Positioning = stats.Positioning
            };
        }
    }
}