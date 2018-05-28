using Backend.Enums;
using Backend.Models;
using Backend.Models.UserModels;
using System;
using System.Linq;

namespace Backend.Builders
{
    public class UserBuilder
    {
        public static User GetUser()
        {
            var user = new User();

            user.FirstName = NameBuilder.GetFirstName();
            user.LastName = NameBuilder.GetLastName();
            user.Country = Country.England;
            user.Coins = 0;
            user.Boosters = 10;

            user.UserRegisterData = GetUserRegisterData(user);
            user.Club = ClubBuilder.GetClub(user);

            return user;
        }

        public static UserRegisterData GetUserRegisterData(User user)
        {
            var userRegisterData = new UserRegisterData();

            userRegisterData.Id = user.Id;
            userRegisterData.Login = user.FirstName + "." + user.LastName + "@gmail.com";
            userRegisterData.Password = RandomString(8);

            return userRegisterData;
        }

        public static string RandomString(int length)
        {
            var rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
    }
}
