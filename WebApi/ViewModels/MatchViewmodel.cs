using DomainModels.Models.TournamentEntities;

namespace WebApi.ViewModels
{
    public class MatchViewModel
    {
        public int Stage { get; set; }

        public int SubStage { get; set; }

        public string Group { get; set; }

        public int Number { get; set; }

        public long HomeId { get; set; }

        public long VisitorsId { get; set; }

        public long TournamentId { get; set; }

        public static MatchViewModel Get(Match match)
        {
            return new MatchViewModel
            {
                Stage = match.Stage,
                SubStage = match.SubStage,
                Group = match.Group,
                Number = match.Number,
                HomeId = match.HomeId,
                VisitorsId = match.VisitorsId,
                TournamentId = match.TournamentId
            };
        }
    }
}
