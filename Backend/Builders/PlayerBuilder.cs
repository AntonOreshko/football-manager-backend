using Backend.Enums;
using Backend.Helpers;
using Backend.Models;
using Backend.Models.PlayerModels;
using Backend.Models.SquadModels;
using System;
using System.Collections.Generic;

namespace Backend.Builders
{
    public static class PlayerBuilder
    {
        #region random generators

        private static List<PlayerPosition> _playerPositions;

        private static RandomRangesCreator<BodyType> _rndBodyTypeByPosition;

        #endregion

        static PlayerBuilder()
        {
            _bodyTypes = new List<BodyType> { };
            _rndBodyTypeByPosition = new RandomRangesCreator<BodyType>();
        }

        public static Player GetPlayer(Club club, FormationPosition formationPosition)
        {
            var player = new Player();

            player.Club = club;
            player.FirstName = NameBuilder.GetFirstName();
            player.LastName = NameBuilder.GetLastName();
            player.Age = GetAge();
            player.Country = Country.England;
            player.FirstPosition = formationPosition.PlayerPosition;

            return player;
        }

        public static PlayerStats GetPlayerStats(Player player)
        {
            var playerStats = new PlayerStats();

            playerStats.Id = player.Id;

            return playerStats;
        }

        public static PlayerTemporaryStats GetPlayerTemporaryStats(Player player)
        {
            var playerTemporaryStats = new PlayerTemporaryStats();

            playerTemporaryStats.Id = player.Id;
            playerTemporaryStats.Stamnia = 100;
            playerTemporaryStats.StamniaDateTime = DateTime.Now;
            playerTemporaryStats.Morale = 50;
            playerTemporaryStats.MoraleDateTime = DateTime.Now;

            return playerTemporaryStats;
        }

        public static int GetAge()
        {
            var rnd = new Random();
            return rnd.Next(18, 32);
        }

        public static HeightType GetHeightType(int height)
        {
            if (height < 170) return HeightType.Little;
            else if (height < 180) return HeightType.Medium;
            else if (height < 190) return HeightType.UpperMedium;
            else return HeightType.Tall;
        }

        public static int GetRandomHeight()
        {
            var rnd = new Random();

            return rnd.Next(160, 200);
        }

        public static int GetRandomHeight(HeightType heightType)
        {
            var rnd = new Random();
            switch (heightType)
            {
                case HeightType.Little:
                    return rnd.Next(160, 170);
                case HeightType.Medium:
                    return rnd.Next(170, 180);
                case HeightType.UpperMedium:
                    return rnd.Next(180, 190);
                case HeightType.Tall:
                    return rnd.Next(190, 200);
            }
            
            throw new Exception("Unable to generate height");
        }

        public static BodyType GetBodyTypeByPosition()
        {

        }
    }
}
