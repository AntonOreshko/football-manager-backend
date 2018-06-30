using System;
using System.Collections.Generic;
using BusinessLayer.Builders.BuildersData;
using BusinessLayer.Mappers;
using DomainModels.Enums;
using DomainModels.Models.ClubEntities;
using DomainModels.Models.PlayerEntities;
using DomainModels.Models.SquadEntities;
using DomainModels.Models.UserEntities;
using Utility.Helpers;

namespace BusinessLayer.Builders
{
    public static class ClubBuilder
    {
        private class PlayerBuilderData : IPlayerBuilderData
        {
            public Country Country { get; set; }

            public PlayerPosition Position { get; set; }

            public int Level { get; set; }
        }

        private static readonly StartPlayerLevelsMapper StartPlayerLevelsMapper;

        static ClubBuilder()
        {
            StartPlayerLevelsMapper = ConfigBuilder.GetConfig<StartPlayerLevelsMapper>().Get();
        }

        public static Club Get(IClubBuilderData clubBuilderData)
        {
            var club = new Club()
            {
                Name = clubBuilderData.Name,
                Country = clubBuilderData.Country
            };

            return club;
        }

        public static Club GetRandom(User user)
        {
            var club = new Club
            {
                Name = user.FirstName + "'s Club",
                Country = user.Country,
                Players = new List<Player>(),
                Squads = new List<Squad>(),
                FoundationDate = DateTime.Now
            };


            var squad = SquadBuilder.GetRandomSquad();
            club.Squads.Add(squad);

            club.Players = GeneratePlayers(club, squad);

            return club;
        }

        private static List<Player> GeneratePlayers(Club club, Squad squad)
        {
            var shuffledPositions = new RandomShuffleListCreator<FormationPosition>(squad.FormationPositions);

            var shuffledLevels = new RandomShuffleListCreator<int>(StartPlayerLevelsMapper.Levels);

            var players = new List<Player>();

            for (int i = 0; i < squad.FormationPositions.Count; i++)
            {
                var formationPosition = shuffledPositions.Pop();
                var level = shuffledLevels.Pop();

                players.Add(PlayerBuilder.Get(new PlayerBuilderData()
                {
                    Country = club.Country,
                    Position = formationPosition.PlayerPosition,
                    Level = level
                }));
            }

            return players;
        }
    }

}

