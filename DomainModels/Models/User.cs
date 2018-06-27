using DomainModels.Enums;
using DomainModels.Interfaces;

namespace DomainModels.Models
{
    public class User : IDatabaseEntity, IPerson
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Country Country { get; set; }

        public int Coins { get; set; }

        public int Boosters { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public Club Club { get; set; }
    }
}
