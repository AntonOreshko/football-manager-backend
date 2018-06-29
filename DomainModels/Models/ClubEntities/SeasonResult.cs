using DomainModels.Interfaces;

namespace DomainModels.Models.ClubEntities
{
    public class SeasonResult : IDatabaseEntity
    {
        public long Id { get; set; }

        public int LeaguePlace { get; set; }

        public int SuperleagueStage { get; set; }

        public long ClubHistoryId { get; set; }

        public ClubHistory ClubHistory { get; set; }
    }
}
