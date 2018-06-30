using System.Collections.Generic;
using BusinessLayer.Mappers.TournamentMappers;

namespace BusinessLayer.Mappers.TournamentMappers
{
    public class LeagueMapper
    {
        public List<LeagueStage> Stages { get; set; }
        //= new List<LeagueStage>
        //{
        //    new LeagueStage()
        //    {
        //        Stage = 1,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage { HomeId = 1, VisitorsId = 10, Number = 1 },
        //            new MatchStage { HomeId = 2, VisitorsId = 9, Number = 2 },
        //            new MatchStage { HomeId = 3, VisitorsId = 8, Number = 3 },
        //            new MatchStage { HomeId = 4, VisitorsId = 7, Number = 4 },
        //            new MatchStage { HomeId = 5, VisitorsId = 6, Number = 5 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 2,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage { HomeId = 10, VisitorsId = 6, Number = 6 },
        //            new MatchStage { HomeId = 7, VisitorsId = 5, Number = 7 },
        //            new MatchStage { HomeId = 8, VisitorsId = 4, Number = 8 },
        //            new MatchStage { HomeId = 9, VisitorsId = 3, Number = 9 },
        //            new MatchStage { HomeId = 1, VisitorsId = 2, Number = 10 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 3,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage { HomeId = 2, VisitorsId = 10, Number = 11 },
        //            new MatchStage { HomeId = 3, VisitorsId = 1, Number = 12 },
        //            new MatchStage { HomeId = 4, VisitorsId = 9, Number = 13 },
        //            new MatchStage { HomeId = 5, VisitorsId = 8, Number = 14 },
        //            new MatchStage { HomeId = 6, VisitorsId = 7, Number = 15 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 4,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage { HomeId = 10, VisitorsId = 7, Number = 16 },
        //            new MatchStage { HomeId = 8, VisitorsId = 6, Number = 17 },
        //            new MatchStage { HomeId = 9, VisitorsId = 5, Number = 18 },
        //            new MatchStage { HomeId = 1, VisitorsId = 4, Number = 19 },
        //            new MatchStage { HomeId = 2, VisitorsId = 3, Number = 20 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 5,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage { HomeId = 3, VisitorsId = 10, Number = 21 },
        //            new MatchStage { HomeId = 4, VisitorsId = 2, Number = 22 },
        //            new MatchStage { HomeId = 5, VisitorsId = 1, Number = 23 },
        //            new MatchStage { HomeId = 6, VisitorsId = 9, Number = 24 },
        //            new MatchStage { HomeId = 7, VisitorsId = 8, Number = 25 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 6,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage { HomeId = 10, VisitorsId = 8, Number = 26 },
        //            new MatchStage { HomeId = 9, VisitorsId = 7, Number = 27 },
        //            new MatchStage { HomeId = 1, VisitorsId = 6, Number = 28 },
        //            new MatchStage { HomeId = 2, VisitorsId = 5, Number = 29 },
        //            new MatchStage { HomeId = 3, VisitorsId = 4, Number = 30 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 7,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage { HomeId = 4, VisitorsId = 10, Number = 31 },
        //            new MatchStage { HomeId = 5, VisitorsId = 3, Number = 32 },
        //            new MatchStage { HomeId = 6, VisitorsId = 2, Number = 33 },
        //            new MatchStage { HomeId = 7, VisitorsId = 1, Number = 34 },
        //            new MatchStage { HomeId = 8, VisitorsId = 9, Number = 35 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 8,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage { HomeId = 10, VisitorsId = 9, Number = 36 },
        //            new MatchStage { HomeId = 1, VisitorsId = 8, Number = 37 },
        //            new MatchStage { HomeId = 2, VisitorsId = 7, Number = 38 },
        //            new MatchStage { HomeId = 3, VisitorsId = 6, Number = 39 },
        //            new MatchStage { HomeId = 4, VisitorsId = 5, Number = 40 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 9,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage { HomeId = 5, VisitorsId = 10, Number = 41 },
        //            new MatchStage { HomeId = 6, VisitorsId = 4, Number = 42 },
        //            new MatchStage { HomeId = 7, VisitorsId = 3, Number = 43 },
        //            new MatchStage { HomeId = 8, VisitorsId = 2, Number = 44 },
        //            new MatchStage { HomeId = 9, VisitorsId = 1, Number = 45 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 10,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage { HomeId = 10, VisitorsId = 1, Number = 46 },
        //            new MatchStage { HomeId = 9, VisitorsId = 2, Number = 47 },
        //            new MatchStage { HomeId = 8, VisitorsId = 3, Number = 48 },
        //            new MatchStage { HomeId = 7, VisitorsId = 4, Number = 49 },
        //            new MatchStage { HomeId = 6, VisitorsId = 5, Number = 50 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 11,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage { HomeId = 6, VisitorsId = 10, Number = 51 },
        //            new MatchStage { HomeId = 5, VisitorsId = 7, Number = 52 },
        //            new MatchStage { HomeId = 4, VisitorsId = 8, Number = 53 },
        //            new MatchStage { HomeId = 3, VisitorsId = 9, Number = 54 },
        //            new MatchStage { HomeId = 2, VisitorsId = 1, Number = 55 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 12,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage { HomeId = 10, VisitorsId = 2, Number = 56 },
        //            new MatchStage { HomeId = 1, VisitorsId = 3, Number = 57 },
        //            new MatchStage { HomeId = 9, VisitorsId = 4, Number = 58 },
        //            new MatchStage { HomeId = 8, VisitorsId = 5, Number = 59 },
        //            new MatchStage { HomeId = 7, VisitorsId = 6, Number = 60 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 13,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage { HomeId = 7, VisitorsId = 10, Number = 61 },
        //            new MatchStage { HomeId = 6, VisitorsId = 8, Number = 62 },
        //            new MatchStage { HomeId = 5, VisitorsId = 9, Number = 63 },
        //            new MatchStage { HomeId = 4, VisitorsId = 1, Number = 64 },
        //            new MatchStage { HomeId = 3, VisitorsId = 2, Number = 65 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 14,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage { HomeId = 10, VisitorsId = 3, Number = 66 },
        //            new MatchStage { HomeId = 2, VisitorsId = 4, Number = 67 },
        //            new MatchStage { HomeId = 1, VisitorsId = 5, Number = 68 },
        //            new MatchStage { HomeId = 9, VisitorsId = 6, Number = 69 },
        //            new MatchStage { HomeId = 8, VisitorsId = 7, Number = 70 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 15,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage { HomeId = 8, VisitorsId = 10, Number = 71 },
        //            new MatchStage { HomeId = 7, VisitorsId = 9, Number = 72 },
        //            new MatchStage { HomeId = 6, VisitorsId = 1, Number = 73 },
        //            new MatchStage { HomeId = 5, VisitorsId = 2, Number = 74 },
        //            new MatchStage { HomeId = 4, VisitorsId = 3, Number = 75 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 16,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage { HomeId = 10, VisitorsId = 4, Number = 76 },
        //            new MatchStage { HomeId = 3, VisitorsId = 5, Number = 77 },
        //            new MatchStage { HomeId = 2, VisitorsId = 6, Number = 78 },
        //            new MatchStage { HomeId = 1, VisitorsId = 7, Number = 79 },
        //            new MatchStage { HomeId = 9, VisitorsId = 8, Number = 80 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 17,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage { HomeId = 9, VisitorsId = 10, Number = 81 },
        //            new MatchStage { HomeId = 8, VisitorsId = 1, Number = 82 },
        //            new MatchStage { HomeId = 7, VisitorsId = 2, Number = 83 },
        //            new MatchStage { HomeId = 6, VisitorsId = 3, Number = 84 },
        //            new MatchStage { HomeId = 5, VisitorsId = 4, Number = 85 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 18,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage { HomeId = 10, VisitorsId = 5, Number = 86 },
        //            new MatchStage { HomeId = 6, VisitorsId = 4, Number = 87 },
        //            new MatchStage { HomeId = 3, VisitorsId = 7, Number = 88 },
        //            new MatchStage { HomeId = 2, VisitorsId = 8, Number = 89 },
        //            new MatchStage { HomeId = 1, VisitorsId = 9, Number = 90 },
        //        }
        //    },
        //};
    };
}
