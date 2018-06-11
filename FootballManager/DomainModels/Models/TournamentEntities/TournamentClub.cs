using DomainModels.Interfaces;

namespace DomainModels.Models.TournamentEntities
{
    public class TournamentClub : IDatabaseEntity
    {
        public long Id { get; set; }

        public long TournamentId { get; set; }

        public Tournament Tournament { get; set; }

        public long ClubId { get; set; }

        public Club Club { get; set; }
    }
}
