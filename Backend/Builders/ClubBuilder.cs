using Backend.Models;
using System;
using System.Collections.Generic;
using Backend.Builders.Data;
using Backend.Helpers;
using Backend.Models.PlayerModels;
using Backend.Models.SquadModels;

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

            return club;
        }

        public static List<Player> GetStartPlayers(ClubBuilderData data, Squad squad)
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

                players.Add(PlayerBuilder.CreatePlayer(club, formationPosition, level));
            }

            return players;
        }
    }
}
