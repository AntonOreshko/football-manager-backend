using System;
using System.Collections.Generic;
using DomainModels.Interfaces;

namespace DomainModels.Models.TournamentEntities
{
    public class Match : IDatabaseEntity
    {
        public long Id { get; set; }

        public int Stage { get; set; }

        public int SubStage { get; set; }

        public string Group { get; set; }

        public int Number { get; set; }

        public long HomeId { get; set; }

        public long VisitorsId { get; set; }

        public DateTime StartTime { get; set; }

        public long TournamentId { get; set; }

        public Tournament Tournament { get; set; }

        public List<MatchEvent> MatchEvents { get; set; }
    }
}
