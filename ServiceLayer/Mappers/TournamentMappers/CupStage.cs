using System.Collections.Generic;

namespace BusinessLayer.Mappers.TournamentMappers
{
    public class CupStage
    {
        public int Stage { get; set; }

        public List<MatchStage> Matches { get; set; }
    }
}
