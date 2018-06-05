using Backend.Enums;

namespace Backend.ViewModels
{
    public class UserViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Country Country { get; set; }

        public int Coins { get; set; }

        public int Boosters { get; set; }
    }
}
