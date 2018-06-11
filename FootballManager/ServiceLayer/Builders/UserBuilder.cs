using BusinessLayer.Builders.BuildersData;
using DomainModels.Models;

namespace BusinessLayer.Builders
{
    public static class UserBuilder
    {
        public static User Get(IUserBuilderData userBuilderData)
        {
            var user = new User()
            {
                FirstName = userBuilderData.FirstName,
                LastName = userBuilderData.LastName,
                Country = userBuilderData.Country,
                Login = userBuilderData.Login,
                Password = userBuilderData.Password
            };

            return user;
        }
    }
}
