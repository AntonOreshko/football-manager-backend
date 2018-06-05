using System;
using System.Linq;
using Backend.Enums;

namespace Backend.Builders.Data
{
    public class UserBuilderData
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Country UserCountry { get; set; }

        public Country ClubCountry { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public static UserBuilderData GetRandom()
        {
            var builderData = new UserBuilderData();

            builderData.UserCountry = Country.England;
            builderData.UserCountry = Country.England;

            builderData.FirstName = NameBuilder.GetFirstName();
            builderData.LastName = NameBuilder.GetLastName();

            builderData.Login = builderData.FirstName + "." + builderData.LastName + "@gmail.com";
            builderData.Password = RandomPassword(8);

            return builderData;
        }

        public static string RandomPassword(int length)
        {
            var rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

    }
}
