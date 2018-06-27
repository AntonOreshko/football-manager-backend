using DomainModels.Models;

namespace WebApi.ViewModels
{
    public class UserViewModel
    {
        public string FirsName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public int Coins { get; set; }

        public int Boosters { get; set; }

        public static UserViewModel Get(User user)
        {
            return new UserViewModel
            {
                FirsName = user.FirstName,
                LastName = user.LastName,
                Country = user.Country.ToString(),
                Coins = user.Coins,
                Boosters = user.Boosters
            };
        }
    }
}
