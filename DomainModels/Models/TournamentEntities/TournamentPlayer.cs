using DomainModels.Interfaces;
using DomainModels.Models.PlayerEntities;

namespace DomainModels.Models.TournamentEntities
{
    public class TournamentPlayer: IDatabaseEntity
    {
        public long Id { get; set; }

        public long TournamentId { get; set; }

        public Tournament Tournament { get; set; }

        public long PlayerId { get; set; }
    }
}
