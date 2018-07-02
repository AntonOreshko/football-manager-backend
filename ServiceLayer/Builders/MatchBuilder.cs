using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Builders.BuildersData;
using BusinessLayer.Mappers;
using BusinessLayer.Mappers.TournamentMappers;
using BusinessLayer.ServiceInterfaces;
using DomainModels.Enums;
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

            public DateTime StartTime { get; set; }

            public TournamentType TournamentType { get; set; }
        }

        private static readonly LeagueMapper LeagueMapper;

        private static readonly CupMapper CupMapper;

        private static readonly MatchTimeIntervalMapper MatchTimeIntervalMapper;

        static MatchBuilder()
        {
            LeagueMapper = ConfigBuilder.GetConfig<LeagueMapper>().Get();
            CupMapper = ConfigBuilder.GetConfig<CupMapper>().Get();
            MatchTimeIntervalMapper = ConfigBuilder.GetConfig<MatchTimeIntervalMapper>().Get();
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
                VisitorsId = matchBuilderData.VisitorsId,
                StartTime = matchBuilderData.StartTime,
                TournamentType = matchBuilderData.TournamentType
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
                        TournamentType = TournamentType.League
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
                        TournamentType = TournamentType.Cup
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
                        TournamentType = TournamentType.Cup
                    });

                    matches.Add(m);
                }
            }

            return matches;
        }

        public static IEnumerable<Match> SetStartTimeForAllMatches(IMatchService matchService)
        {
            var matches = matchService.GetAll().ToList();

            foreach (var item in MatchTimeIntervalMapper.Items)
            {
                var itemMatches = matches.Where(m => (m.TournamentType == item.TournamentType)
                                                     && m.Number >= item.MatchesInterval[0]
                                                     && m.Number <= item.MatchesInterval[1])
                    .Select(m => m).ToList();

                var intervalMinutes = (item.EndHour - item.BeginHour) * 60;
                var matchDate = GetNextDayOfWeek(item.DayOfWeek);

                matchDate = matchDate.AddHours(item.BeginHour);

                var matchesPerMinute = (int) Math.Ceiling((double)itemMatches.Count / intervalMinutes);

                var currentMinute = 0;
                var counter = 0;
                foreach (var m in itemMatches)
                {
                    m.StartTime = matchDate.AddMinutes(currentMinute);

                    counter++;
                    if (counter == matchesPerMinute)
                    {
                        currentMinute++;
                        counter = 0;
                    }
                }
            }

            return matches;
        }

        private static DateTime GetNextDayOfWeek(DayOfWeek dayOfWeek)
        {
            DateTime startTime = DateTime.Now.Date;

            while (startTime.DayOfWeek != DayOfWeek.Monday)
            {
                startTime = startTime.AddDays(1);
            }

            while (startTime.DayOfWeek != dayOfWeek)
            {
                startTime = startTime.AddDays(1);
            }

            return startTime;
        }
    }
}
