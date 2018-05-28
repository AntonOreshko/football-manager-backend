using Backend.Enums;
using Backend.Models;
using Backend.Models.PlayerModels;
using Backend.Models.SquadModels;
using System;

namespace Backend.Builders
{
    public class PlayerBuilder
    {
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
    }
}
