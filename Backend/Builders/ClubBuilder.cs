using Backend.Models;
using System;
using Backend.Builders.Data;

namespace Backend.Builders
{
    public class ClubBuilder
    {
        public static Club GetClub(ClubBuilderData builderData)
        {
            var club = new Club
            {
                Name = builderData.Name,
                Country = builderData.Country,
                FoundationDate = DateTime.Now
            };


            return club;
        }
    }
}
