using Backend.Builders;
using Backend.Enums;
using Backend.Models.Context;
using Backend.Models.PlayerModels;
using System.Linq;

namespace Backend.ViewModels
{
    public class PlayerViewModel
    {
        public Player Player { get; set; }

        public PlayerStats PlayerStats { get; set; }

        //public PlayerTemporaryStats PlayerTemporaryStats { get; set; }

        public string Position { get; set; }

        public float OverallRating { get; set; }

        public float Speed { get; set; }

        public float Shooting { get; set; }

        public float Passing { get; set; }

        public float Technique { get; set; }

        public float Defending { get; set; }

        public float Physical { get; set; }

        public PlayerViewModel(Player player)
        {
            Player = player;
            Position = player.FirstPosition.ToString();

            OverallRating = PlayerBuilder.GetOverallRating(player.FirstPosition, player.Stats);

            Speed = PlayerBuilder.GetStatsGroupRating(StatsGroup.Speed, player.Stats);
            Shooting = PlayerBuilder.GetStatsGroupRating(StatsGroup.Shooting, player.Stats);
            Passing = PlayerBuilder.GetStatsGroupRating(StatsGroup.Passing, player.Stats);
            Technique = PlayerBuilder.GetStatsGroupRating(StatsGroup.Technique, player.Stats);
            Defending = PlayerBuilder.GetStatsGroupRating(StatsGroup.Defending, player.Stats);
            Physical = PlayerBuilder.GetStatsGroupRating(StatsGroup.Physical, player.Stats);

            Player.Stats = null;
            Player.TemporaryStats = null;

            //PlayerStats = player.Stats;
            //PlayerStats.Stats = null;
            //PlayerStats.Player = null;
        }
    }
}
