using BusinessLayer.Builders.BuildersData;
using DomainModels.Models;

namespace BusinessLayer.Builders
{
    public static class ClubBuilder
    {
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
            var club = new Club()
            {
                Name = user.FirstName + "'s Club",
                Country = user.Country
            };

            return club;
        }
    }
}
