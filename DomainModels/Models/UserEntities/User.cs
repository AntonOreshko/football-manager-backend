using DomainModels.Enums;
using DomainModels.Interfaces;
using DomainModels.Models.ClubEntities;

namespace DomainModels.Models.UserEntities
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

        public UserRole Role { get; set; }

        public Club Club { get; set; }
    }
}
