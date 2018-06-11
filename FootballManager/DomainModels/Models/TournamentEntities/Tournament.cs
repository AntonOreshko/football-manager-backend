using System.Collections.Generic;
using DomainModels.Enums;
using DomainModels.Interfaces;

namespace DomainModels.Models.TournamentEntities
{
    public class Tournament : IDatabaseEntity
    {
        public long Id { get; set; }

        public int Level { get; set; }

        public int CurrentStage { get; set; }

        public TournamentType TournamentType { get; set; }

        public List<TournamentClub> TournamentClubs { get; set; }

        public List<Match> Matches { get; set; }
    }
}
