using System;
using System.Collections.Generic;
using DomainModels.Enums;

namespace BusinessLayer.Mappers
{
    public class MatchTimeIntervalMapper
    {
        public List<MatchTimeIntervalItem> Items { get; set; }
            //= new List<MatchTimeIntervalItem>
            //{
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Monday,
            //        MatchesInterval = new[] { 1, 5 },
            //        TournamentType = TournamentType.League,
            //        BeginHour = 5,
            //        EndHour = 8
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Monday,
            //        MatchesInterval = new[] { 1, 8 },
            //        TournamentType = TournamentType.Cup,
            //        BeginHour = 9,
            //        EndHour = 12
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Monday,
            //        MatchesInterval = new[] { 6, 10 },
            //        TournamentType = TournamentType.League,
            //        BeginHour = 13,
            //        EndHour = 16
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Monday,
            //        MatchesInterval = new[] { 9, 16 },
            //        TournamentType = TournamentType.Cup,
            //        BeginHour = 17,
            //        EndHour = 20
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Monday,
            //        MatchesInterval = new[] { 11, 15 },
            //        TournamentType = TournamentType.League,
            //        BeginHour = 21,
            //        EndHour = 24
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Tuesday,
            //        MatchesInterval = new[] { 16, 20 },
            //        TournamentType = TournamentType.League,
            //        BeginHour = 5,
            //        EndHour = 8
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Tuesday,
            //        MatchesInterval = new[] { 17, 24 },
            //        TournamentType = TournamentType.Cup,
            //        BeginHour = 9,
            //        EndHour = 12
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Tuesday,
            //        MatchesInterval = new[] { 21, 25 },
            //        TournamentType = TournamentType.League,
            //        BeginHour = 13,
            //        EndHour = 16
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Tuesday,
            //        MatchesInterval = new[] { 25, 32 },
            //        TournamentType = TournamentType.Cup,
            //        BeginHour = 17,
            //        EndHour = 20
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Tuesday,
            //        MatchesInterval = new[] { 26, 30 },
            //        TournamentType = TournamentType.League,
            //        BeginHour = 21,
            //        EndHour = 24
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Wednesday,
            //        MatchesInterval = new[] { 31, 35 },
            //        TournamentType = TournamentType.League,
            //        BeginHour = 5,
            //        EndHour = 8
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Wednesday,
            //        MatchesInterval = new[] { 33, 40 },
            //        TournamentType = TournamentType.Cup,
            //        BeginHour = 9,
            //        EndHour = 12
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Wednesday,
            //        MatchesInterval = new[] { 36, 40 },
            //        TournamentType = TournamentType.League,
            //        BeginHour = 13,
            //        EndHour = 16
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Wednesday,
            //        MatchesInterval = new[] { 41, 48 },
            //        TournamentType = TournamentType.Cup,
            //        BeginHour = 17,
            //        EndHour = 20
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Wednesday,
            //        MatchesInterval = new[] { 41, 45 },
            //        TournamentType = TournamentType.League,
            //        BeginHour = 21,
            //        EndHour = 24
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Thursday,
            //        MatchesInterval = new[] { 46, 50 },
            //        TournamentType = TournamentType.League,
            //        BeginHour = 5,
            //        EndHour = 8
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Thursday,
            //        MatchesInterval = new[] { 49, 52 },
            //        TournamentType = TournamentType.Cup,
            //        BeginHour = 9,
            //        EndHour = 12
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Thursday,
            //        MatchesInterval = new[] { 51, 55 },
            //        TournamentType = TournamentType.League,
            //        BeginHour = 13,
            //        EndHour = 16
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Thursday,
            //        MatchesInterval = new[] { 53, 56 },
            //        TournamentType = TournamentType.Cup,
            //        BeginHour = 17,
            //        EndHour = 20
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Thursday,
            //        MatchesInterval = new[] { 56, 60 },
            //        TournamentType = TournamentType.League,
            //        BeginHour = 21,
            //        EndHour = 24
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Friday,
            //        MatchesInterval = new[] { 61, 65 },
            //        TournamentType = TournamentType.League,
            //        BeginHour = 5,
            //        EndHour = 8
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Friday,
            //        MatchesInterval = new[] { 57, 58 },
            //        TournamentType = TournamentType.Cup,
            //        BeginHour = 9,
            //        EndHour = 12
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Friday,
            //        MatchesInterval = new[] { 66, 70 },
            //        TournamentType = TournamentType.League,
            //        BeginHour = 13,
            //        EndHour = 16
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Friday,
            //        MatchesInterval = new[] { 59, 60 },
            //        TournamentType = TournamentType.Cup,
            //        BeginHour = 17,
            //        EndHour = 20
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Friday,
            //        MatchesInterval = new[] { 71, 75 },
            //        TournamentType = TournamentType.League,
            //        BeginHour = 21,
            //        EndHour = 24
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Saturday,
            //        MatchesInterval = new[] { 76, 80 },
            //        TournamentType = TournamentType.League,
            //        BeginHour = 5,
            //        EndHour = 8
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Saturday,
            //        MatchesInterval = new[] { 81, 85 },
            //        TournamentType = TournamentType.League,
            //        BeginHour = 13,
            //        EndHour = 16
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Saturday,
            //        MatchesInterval = new[] { 61, 61 },
            //        TournamentType = TournamentType.Cup,
            //        BeginHour = 17,
            //        EndHour = 20
            //    },
            //    new MatchTimeIntervalItem
            //    {
            //        DayOfWeek = DayOfWeek.Saturday,
            //        MatchesInterval = new[] { 86, 90 },
            //        TournamentType = TournamentType.League,
            //        BeginHour = 21,
            //        EndHour = 24
            //    },
            //};
    }

    public class MatchTimeIntervalItem
    {
        public DayOfWeek DayOfWeek { get; set; }

        public TournamentType TournamentType { get; set; }

        public int[] MatchesInterval { get; set; }

        public int BeginHour { get; set; }

        public int EndHour { get; set; }
    }
}
