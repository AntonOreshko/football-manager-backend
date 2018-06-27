using DomainModels.Enums;
using DomainModels.Interfaces;
using DomainModels.Models.PlayerEntities;

namespace DomainModels.Models.TournamentEntities
{
    public class MatchEvent : IDatabaseEntity
    {
        public long Id { get; set; }

        public long MatchId { get; set; }

        public Match Match { get; set; }

        public MatchEventType MatchEventType { get; set; }

        public long PlayerId { get; set; }
    }
}
