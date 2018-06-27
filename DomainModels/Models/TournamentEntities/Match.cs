using System.Collections.Generic;
using DomainModels.Interfaces;

namespace DomainModels.Models.TournamentEntities
{
    public class Match : IDatabaseEntity
    {
        public long Id { get; set; }

        public long HomeId { get; set; }

        public long VisitorsId { get; set; }

        public long TournamentId { get; set; }

        public Tournament Tournament { get; set; }

        public List<MatchEvent> MatchEvents { get; set; }
    }
}
