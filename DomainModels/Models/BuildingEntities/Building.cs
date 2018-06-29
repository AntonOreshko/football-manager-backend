using DomainModels.Interfaces;
using DomainModels.Models.ClubEntities;

namespace DomainModels.Models.BuildingEntities
{
    public class Building : IDatabaseEntity, IUpgradable
    {
        public long Id { get; set; }

        public int Level { get; set; }

        public long ClubId { get; set; }

        public Club Club { get; set; }
    }
}
