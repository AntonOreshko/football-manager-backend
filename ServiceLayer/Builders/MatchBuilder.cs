using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Builders.BuildersData;
using BusinessLayer.Mappers.TournamentMappers;
using DomainModels.Models.ClubEntities;
using DomainModels.Models.TournamentEntities;
using Utility.Helpers;

namespace BusinessLayer.Builders
{
    public static class MatchBuilder
    {
        private class MatchBuilderData : IMatchBuilderData
        {
            public int Stage { get; set; }

            public int SubStage { get; set; }

            public string Group { get; set; }

            public int Number { get; set; }

            public long HomeId { get; set; }

            public long VisitorsId { get; set; }
        }

        private static readonly LeagueMapper LeagueMapper;

        private static readonly CupMapper CupMapper;

        static MatchBuilder()
        {
            LeagueMapper = ConfigBuilder.GetConfig<LeagueMapper>().Get();
            CupMapper = ConfigBuilder.GetConfig<CupMapper>().Get();
        }

        public static Match Get(IMatchBuilderData matchBuilderData)
        {
            return new Match
            {
                Stage = matchBuilderData.Stage,
                SubStage = matchBuilderData.SubStage,
                Group = matchBuilderData.Group,
                Number = matchBuilderData.Number,
                HomeId = matchBuilderData.HomeId,
                VisitorsId = matchBuilderData.VisitorsId
            };
        }

        public static IEnumerable<Match> GetLeagueMatches(Tournament tournament)
        {
            var clubs = tournament.TournamentClubs.Select(tc => tc.Club).ToList();
            var shuffledClubbsList = new RandomShuffleListCreator<Club>(clubs);

            var clubKeyValues = new Dictionary<int, Club>();
            for (var i = 1; i <= 10; i++)
            {
                clubKeyValues.Add(i, shuffledClubbsList.Pop());
            }

            var matches = new List<Match>();
            foreach (var stage in LeagueMapper.Stages)
            {
                foreach (var match in stage.Matches)
                {
                    var m = Get(new MatchBuilderData
                    {
                        Stage = stage.Stage,
                        Number = match.Number,
                        HomeId = clubKeyValues[match.HomeId].Id,
                        VisitorsId = clubKeyValues[match.VisitorsId].Id,
                    });

                    matches.Add(m);
                }
            }

            return matches;
        }

        public static IEnumerable<Match> GetCupMatches(Tournament tournament)
        {
            var clubs = tournament.TournamentClubs.Select(tc => tc.Club).ToList();
            var shuffledClubbsList = new RandomShuffleListCreator<Club>(clubs);

            var clubKeyValues = new Dictionary<int, Club>();
            for (var i = 1; i <= 16; i++)
            {
                clubKeyValues.Add(i, shuffledClubbsList.Pop());
            }

            var matches = new List<Match>();
            foreach (var stage in CupMapper.LeagueStages)
            {
                foreach (var match in stage.Matches)
                {
                    var m = Get(new MatchBuilderData
                    {
                        Stage = stage.Stage,
                        Number = match.Number,
                        HomeId = clubKeyValues[match.HomeId].Id,
                        VisitorsId = clubKeyValues[match.VisitorsId].Id,
                        Group = match.Group,
                    });

                    matches.Add(m);
                }
            }

            foreach (var stage in CupMapper.CupStages)
            {
                foreach (var match in stage.Matches)
                {
                    var m = Get(new MatchBuilderData
                    {
                        Stage = stage.Stage,
                        Number = match.Number,
                        HomeId = match.HomeId,
                        VisitorsId = match.VisitorsId,
                        SubStage = match.Substage,
                    });

                    matches.Add(m);
                }
            }

            return matches;
        }
    }
}
