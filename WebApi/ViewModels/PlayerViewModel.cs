using DomainModels.Models.PlayerEntities;

namespace WebApi.ViewModels
{
    public class PlayerViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public int Age { get; set; }

        public int Talent { get; set; }

        public string Position { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public PlayerStatsViewModel Stats { get; set; }

        public static PlayerViewModel Get(Player player)
        {
            return new PlayerViewModel
            {
                FirstName = player.FirstName,
                LastName = player.LastName,
                Country = player.Country.ToString(),
                Age = player.Age,
                Talent = player.Talent,
                Position = player.Position.ToString(),
                Height = player.Height,
                Weight = player.Weight,
                Stats = PlayerStatsViewModel.Get(player)
            };
        }
    }
}
