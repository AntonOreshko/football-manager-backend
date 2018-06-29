using DomainModels.Enums;
using DomainModels.Interfaces;
using DomainModels.Models.ClubEntities;

namespace DomainModels.Models.PlayerEntities
{
    public class Player : IDatabaseEntity, IPerson
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Country Country { get; set; }

        public int Age { get; set; }

        public int Talent { get; set; }

        public PlayerPosition Position { get; set; }

        public HeightType HeightType { get; set; }

        public BodyType BodyType { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public long ClubId { get; set; }

        public Club Club { get; set; }

        public PlayerStats Stats { get; set; }

        public PlayerTemporaryStats TemporaryStats { get; set; }

        public PlayerScores Scores { get; set; }
    }
}
