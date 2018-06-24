using System.Collections.Generic;
using BusinessLayer.Builders.BuildersData;
using BusinessLayer.Mappers;
using DomainModels.Models;
using DomainModels.Models.PlayerEntities;

namespace BusinessLayer.Builders
{
    public static class ClubBuilder
    {
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
                Players = new List<Player>()
            };

            club.Players.Add(PlayerBuilder.Get(null));

            return club;
        }
    }
}
