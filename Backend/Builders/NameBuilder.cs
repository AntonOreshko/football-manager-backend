using System;
using System.Collections.Generic;
using Backend.Interfaces;

namespace Backend.Builders
{
    public class NameBuilder
    {
        #region names

        private static List<string> _firstNames = new List<string>
        {
            "Oliver", "Jack", "Harry", "Jacob", "Charlie", "Thomas", "George", "Oscar", "James", "William"
        };

        private static List<string> _lastNames = new List<string>
        {
            "Smith", "Jones", "Williams", "Brown", "Taylor", "Davies", "Wilson", "Evans", "Thomas", "Roberts"
        };

        #endregion

        public static string GetFirstName()
        {
            var rnd = new Random();
            var idx = rnd.Next(_firstNames.Count);

            return _firstNames[idx];
        }

        public static string GetLastName()
        {
            var rnd = new Random();
            var idx = rnd.Next(_lastNames.Count);

            return _lastNames[idx];
        }

        public static void SetPersonInfo(IPerson person)
        {
            person.FirstName = GetFirstName();
            person.LastName = GetLastName();
        }
    }
}
