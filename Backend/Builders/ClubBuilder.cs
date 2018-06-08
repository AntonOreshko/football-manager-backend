using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Builders.Buildings;
using Backend.Builders.Data;
using Backend.Helpers;
using Backend.Models.BuildingModels;
using Backend.Models.PlayerModels;
using Backend.Models.SquadModels;
using Backend.Models.StaffModels;

namespace Backend.Builders
{
    public class ClubBuilder
    {
        public static Club GetClub(ClubBuilderData clubBuilderData)
        {
            var club = new Club
            {
                Name = clubBuilderData.Name,
                Country = clubBuilderData.Country,
                FoundationDate = DateTime.Now,
                Squads = new List<Squad>()
            };

            var squad = SquadBuilder.GetSquad(new SquadBuilderData
            {
                Formation = clubBuilderData.Formation,
                IsActive = true
            });
            club.Squads.Add(squad);

            club.Players = GetStartPlayers(clubBuilderData, squad);

            club.Buildings = new List<Building>()
            {
                AcademyBuilder.GetAcademy(),
                FanClubBuilder.GetFanClub(),
                MedicalCenterBuilder.GetMedicalCenter(),
                StadiumBuilder.GetStadium(),
                TrainingCenterBuilder.GetTrainingCenter()
            };

            club.Staff = new List<Employee>()
            {
                StaffBuilder.GetHeadCoach(1, clubBuilderData.Country),
                StaffBuilder.GetMedic(1, clubBuilderData.Country),
                StaffBuilder.GetPsychologist(1, clubBuilderData.Country),
                StaffBuilder.GetScout(1, clubBuilderData.Country),
            };

            return club;
        }

        public static List<Player> GetStartPlayers(ClubBuilderData clubBuilderData, Squad squad)
        {
            var shuffledPositions = new RandomShuffleListCreator<FormationPosition>(squad.FormationPositions);

            var shuffledLevels = new RandomShuffleListCreator<int>(new List<int>
            {
                1, 1, 1, 1, 1, 1, 1, 1,
                2, 2, 2, 2, 2, 2,
                3, 3, 3, 3
            });

            var players = new List<Player>();

            for (int i = 0; i < squad.FormationPositions.Count; i++)
            {
                var formationPosition = shuffledPositions.Get();
                var level = shuffledLevels.Get();

                players.Add(PlayerBuilder.GetPlayer(new PlayerBuilderData
                {
                    Country = clubBuilderData.Country, Level = level, Position = formationPosition.PlayerPosition
                }));
            }
            
            return players;
        }

        public static void FillSquad(Squad squad, List<Player> players)
        {
            var addedPlayers = new List<Player>();

            foreach (var pos in squad.FormationPositions)
            {
                var pl = players.Where(p => p.FirstPosition == pos.PlayerPosition && !addedPlayers.Contains(p))
                    .OrderByDescending(p => p.OverallRating)
                    .First();

                pos.PlayerId = pl.Id;
            }
        }
    }
}
