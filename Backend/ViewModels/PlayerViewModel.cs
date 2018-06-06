using Backend.Builders;
using Backend.Enums;
using Backend.Models.PlayerModels;

namespace Backend.ViewModels
{
    public class PlayerViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public int Age { get; set; }

        public int Talent { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public float OverallRating { get; set; }

        public float Speed { get; set; }

        public float Shooting { get; set; }

        public float Passing { get; set; }

        public float Technique { get; set; }

        public float Defending { get; set; }

        public float Physical { get; set; }

        public float Goalkeeping { get; set; }

        public PlayerViewModel(Player player)
        {
            FirstName = player.FirstName;
            LastName = player.LastName;
            Age = player.Age;
            Talent = player.Talent;
            Height = player.Height;
            Weight = player.Weight;

            Position = player.FirstPosition.ToString();

            OverallRating = PlayerBuilder.GetOverallRating(player.FirstPosition, player.Stats);

            Speed = PlayerBuilder.GetStatsGroupRating(StatsGroup.Speed, player.Stats);
            Shooting = PlayerBuilder.GetStatsGroupRating(StatsGroup.Shooting, player.Stats);
            Passing = PlayerBuilder.GetStatsGroupRating(StatsGroup.Passing, player.Stats);
            Technique = PlayerBuilder.GetStatsGroupRating(StatsGroup.Technique, player.Stats);
            Defending = PlayerBuilder.GetStatsGroupRating(StatsGroup.Defending, player.Stats);
            Physical = PlayerBuilder.GetStatsGroupRating(StatsGroup.Physical, player.Stats);
            Goalkeeping = PlayerBuilder.GetStatsGroupRating(StatsGroup.Goalkeeping, player.Stats);
        }
    }
}
