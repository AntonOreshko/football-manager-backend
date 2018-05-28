using Backend.Models;
using Backend.Models.PlayerModels;
using Backend.Models.SquadModels;
using Backend.Models.UserModels;
using System;
using System.Collections.Generic;

namespace Backend.Builders
{
    public class ClubBuilder
    {
        public static Club GetClub(User user)
        {
            var club = new Club();

            club.Name = user.FirstName + "'s Club";
            club.FoundationDate = DateTime.Now;
            club.User = user;

            var squad = SquadBuilder.GetSquad(club, FormationBuilder.GetRandomFormation());
            club.Squads = new List<Squad>();
            club.Squads.Add(squad);

            var formationData = squad.FormationData;
            club.Players = new List<Player>();
            foreach(var fp in formationData.FormationPositions)
            {
                club.Players.Add(PlayerBuilder.GetPlayer(club, fp));
            }

            return club;
        }
    }
}
