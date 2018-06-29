using DomainModels.Enums;
using DomainModels.Interfaces;
using DomainModels.Models.ClubEntities;

namespace DomainModels.Models.PlayerEntities
{
    public class Legend : IDatabaseEntity
    {
        public long Id { get; set; }

        public LegendType LegendType { get; set; }

        public int Result { get; set; }

        public int Matches { get; set; }

        public long HollOfFameId { get; set; }

        public HollOfFame HollOfFame { get; set; }

        public long PlayerId { get; set; }
    }
}
