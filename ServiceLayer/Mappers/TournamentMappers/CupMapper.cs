using System.Collections.Generic;

namespace BusinessLayer.Mappers.TournamentMappers
{
    public class CupMapper
    {
        public List<LeagueStage> LeagueStages { get; set; } 
        //    = new List<LeagueStage>
        //{
        //    new LeagueStage()
        //    {
        //        Stage = 1,
        //        Matches = new List<MatchStage>()
        //        {
        //            new MatchStage() { HomeId = 1, VisitorsId = 2, Group = "A" , Number = 1 },
        //            new MatchStage() { HomeId = 3, VisitorsId = 4, Group = "A" , Number = 2 },

        //            new MatchStage() { HomeId = 5, VisitorsId = 6, Group = "B" , Number = 3 },
        //            new MatchStage() { HomeId = 7, VisitorsId = 8, Group = "B" , Number = 4 },

        //            new MatchStage() { HomeId = 9, VisitorsId = 10, Group = "C" , Number = 5 },
        //            new MatchStage() { HomeId = 11, VisitorsId = 12, Group = "C" , Number = 6 },

        //            new MatchStage() { HomeId = 13, VisitorsId = 14, Group = "D" , Number = 7 },
        //            new MatchStage() { HomeId = 15, VisitorsId = 16, Group = "D" , Number = 8 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 1,
        //        Matches = new List<MatchStage>()
        //        {
        //            new MatchStage() { HomeId = 4, VisitorsId = 1, Group = "A" , Number = 9 },
        //            new MatchStage() { HomeId = 2, VisitorsId = 3, Group = "A" , Number = 10 },

        //            new MatchStage() { HomeId = 6, VisitorsId = 7, Group = "B" , Number = 11 },
        //            new MatchStage() { HomeId = 8, VisitorsId = 5, Group = "B" , Number = 12 },

        //            new MatchStage() { HomeId = 10, VisitorsId = 11, Group = "C" , Number = 13 },
        //            new MatchStage() { HomeId = 12, VisitorsId = 9, Group = "C" , Number = 14 },

        //            new MatchStage() { HomeId = 14, VisitorsId = 15, Group = "D" , Number = 15 },
        //            new MatchStage() { HomeId = 16, VisitorsId = 13, Group = "D" , Number = 16 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 1,
        //        Matches = new List<MatchStage>()
        //        {
        //            new MatchStage() { HomeId = 2, VisitorsId = 4, Group = "A" , Number = 17 },
        //            new MatchStage() { HomeId = 3, VisitorsId = 1, Group = "A" , Number = 18 },

        //            new MatchStage() { HomeId = 8, VisitorsId = 6, Group = "B" , Number = 19 },
        //            new MatchStage() { HomeId = 5, VisitorsId = 7, Group = "B" , Number = 20 },

        //            new MatchStage() { HomeId = 12, VisitorsId = 10, Group = "C" , Number = 21 },
        //            new MatchStage() { HomeId = 9, VisitorsId = 11, Group = "C" , Number = 22 },

        //            new MatchStage() { HomeId = 16, VisitorsId = 14, Group = "D" , Number = 23 },
        //            new MatchStage() { HomeId = 13, VisitorsId = 15, Group = "D" , Number = 24 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 1,
        //        Matches = new List<MatchStage>()
        //        {
        //            new MatchStage() { HomeId = 2, VisitorsId = 1, Group = "A" , Number = 25 },
        //            new MatchStage() { HomeId = 4, VisitorsId = 3, Group = "A" , Number = 26 },

        //            new MatchStage() { HomeId = 6, VisitorsId = 5, Group = "B" , Number = 27 },
        //            new MatchStage() { HomeId = 8, VisitorsId = 7, Group = "B" , Number = 28 },

        //            new MatchStage() { HomeId = 10, VisitorsId = 9, Group = "C" , Number = 29 },
        //            new MatchStage() { HomeId = 12, VisitorsId = 11, Group = "C" , Number = 30 },

        //            new MatchStage() { HomeId = 14, VisitorsId = 13, Group = "D" , Number = 31 },
        //            new MatchStage() { HomeId = 16, VisitorsId = 15, Group = "D" , Number = 32 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 1,
        //        Matches = new List<MatchStage>()
        //        {
        //            new MatchStage() { HomeId = 1, VisitorsId = 4, Group = "A" , Number = 33 },
        //            new MatchStage() { HomeId = 3, VisitorsId = 2, Group = "A" , Number = 34 },

        //            new MatchStage() { HomeId = 7, VisitorsId = 6, Group = "B" , Number = 35 },
        //            new MatchStage() { HomeId = 5, VisitorsId = 8, Group = "B" , Number = 36 },

        //            new MatchStage() { HomeId = 11, VisitorsId = 10, Group = "C" , Number = 37 },
        //            new MatchStage() { HomeId = 9, VisitorsId = 12, Group = "C" , Number = 38 },

        //            new MatchStage() { HomeId = 15, VisitorsId = 14, Group = "D" , Number = 39 },
        //            new MatchStage() { HomeId = 13, VisitorsId = 16, Group = "D" , Number = 40 },
        //        }
        //    },
        //    new LeagueStage()
        //    {
        //        Stage = 1,
        //        Matches = new List<MatchStage>()
        //        {
        //            new MatchStage() { HomeId = 4, VisitorsId = 2, Group = "A" , Number = 41 },
        //            new MatchStage() { HomeId = 1, VisitorsId = 3, Group = "A" , Number = 42 },

        //            new MatchStage() { HomeId = 6, VisitorsId = 8, Group = "B" , Number = 43 },
        //            new MatchStage() { HomeId = 7, VisitorsId = 5, Group = "B" , Number = 44 },

        //            new MatchStage() { HomeId = 10, VisitorsId = 12, Group = "C" , Number = 45 },
        //            new MatchStage() { HomeId = 11, VisitorsId = 9, Group = "C" , Number = 46 },

        //            new MatchStage() { HomeId = 14, VisitorsId = 16, Group = "D" , Number = 47 },
        //            new MatchStage() { HomeId = 15, VisitorsId = 13, Group = "D" , Number = 48 },
        //        }
        //    },
        //};

        public List<CupStage> CupStages { get; set; } 
        //    = new List<CupStage>
        //{
        //    new CupStage
        //    {
        //        Stage = 1,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage(){ HomeId = -1, VisitorsId = -1, Number = 49, Substage = 1 },
        //            new MatchStage(){ HomeId = -1, VisitorsId = -1, Number = 50, Substage = 1 },
        //            new MatchStage(){ HomeId = -1, VisitorsId = -1, Number = 51, Substage = 1 },
        //            new MatchStage(){ HomeId = -1, VisitorsId = -1, Number = 52, Substage = 1 },

        //            new MatchStage(){ HomeId = -1, VisitorsId = -1, Number = 53, Substage = 2 },
        //            new MatchStage(){ HomeId = -1, VisitorsId = -1, Number = 54, Substage = 2 },
        //            new MatchStage(){ HomeId = -1, VisitorsId = -1, Number = 55, Substage = 2 },
        //            new MatchStage(){ HomeId = -1, VisitorsId = -1, Number = 56, Substage = 2 },
        //        },
        //    },
        //    new CupStage
        //    {
        //        Stage = 2,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage(){ HomeId = -1, VisitorsId = -1, Number = 57, Substage = 1 },
        //            new MatchStage(){ HomeId = -1, VisitorsId = -1, Number = 58, Substage = 1 },

        //            new MatchStage(){ HomeId = -1, VisitorsId = -1, Number = 59, Substage = 2 },
        //            new MatchStage(){ HomeId = -1, VisitorsId = -1, Number = 60, Substage = 2 },
        //        }
        //    },
        //    new CupStage
        //    {
        //        Stage = 3,
        //        Matches = new List<MatchStage>
        //        {
        //            new MatchStage(){ HomeId = -1, VisitorsId = -1, Number = 61 },
        //        }
        //    },
        //};
    }
}