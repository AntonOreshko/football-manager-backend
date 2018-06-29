using System;
using System.Linq;
using BusinessLayer.Builders.BuildersData;
using BusinessLayer.Builders.UtilityBuilder;
using DomainModels.Enums;
using DomainModels.Interfaces;
using DomainModels.Models;
using DomainModels.Models.UserEntities;
using Utility;


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

        public static User GetRandom()
        {
            var user = new User()
            {
                Country = typeof(Country).GetRandom<Country>()
            };

            PersonBuilder.SetPerson(user);

            user.Login = DefaultLogin(user);
            user.Password = RandomPassword(8);

            user.Club = ClubBuilder.GetRandom(user);

            return user;
        }

        private static string DefaultLogin(IPerson person)
        {
            return person.FirstName + "." + person.LastName + "@gmail.com";
        }

        private static string RandomPassword(int length)
        {
            var rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
    }
}
