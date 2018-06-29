using DomainModels.Interfaces;

namespace DomainModels.Models.PlayerEntities
{
    public class PlayerScores : IDatabaseEntity
    {
        public long Id { get; set; }

        public Player Player { get; set; }

        public int TotalLeagueScores { get; set; }

        public int TotalLeagueAssists { get; set; }

        public int TotalLeagueMatches { get; set; }

        public float TotalLeagueRating { get; set; }

        public int CurrentLeagueScores { get; set; }

        public int CurrentLeagueAssists { get; set; }

        public int CurrentLeagueMatches { get; set; }

        public float CurrentLeagueRating { get; set; }

        public int TotalSuperleagueScores { get; set; }

        public int TotalSuperleagueAssists { get; set; }

        public int TotalSuperleagueMatches { get; set; }

        public float TotalSuperleagueRating { get; set; }

        public int CurrentSuperleagueScores { get; set; }

        public int CurrentSuperleagueAssists { get; set; }

        public int CurrentSuperleagueMatches { get; set; }

        public float CurrentSuperleagueRating { get; set; }
    }
}
