using Backend.Models.UserModels;
using Backend.Builders.Data;

namespace Backend.Builders
{
    public class UserBuilder
    {
        public static User GetUser(UserBuilderData builderData)
        {
            var user = new User
            {
                FirstName = builderData.FirstName,
                LastName = builderData.LastName,
                Country = builderData.UserCountry,
                Login = builderData.Login,
                Password = builderData.Password,
                Coins = 0,
                Boosters = 0,
            };

            return user;
        }

        public static User GetRandomUser()
        {
            var userBuilderData = UserBuilderData.GetRandom();

            var user = GetUser(userBuilderData);

            user.Club = ClubBuilder.GetClub(ClubBuilderData.GetRandom(userBuilderData));

            return user;
        }
    }
}
