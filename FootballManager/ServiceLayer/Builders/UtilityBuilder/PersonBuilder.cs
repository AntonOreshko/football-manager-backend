using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Data;
using BusinessLayer.Mappers;
using DomainModels.Enums;
using DomainModels.Interfaces;
using Utility;

namespace BusinessLayer.Builders.UtilityBuilder
{
    public static class PersonBuilder
    {
        private static CountryMapper countryMapper = new CountryMapper();

        private static HashSet<CountryNameMap> countryNameMaps = new HashSet<CountryNameMap>();

        static PersonBuilder()
        {
            var countryList = typeof(Country).ToList<Country>();
            foreach (var country in countryList)
            {
                countryNameMaps.Add(new CountryNameMap(country, countryMapper));
            }
        }

        public static string GetFirstName(Country country)
        {
            return countryNameMaps.First(cm => cm.Country == country).GetRandomFirstName();
        }

        public static string GetLastName(Country country)
        {
            return countryNameMaps.First(cm => cm.Country == country).GetRandomLastName();
        }

        public static void SetPerson(IPerson person)
        {
            person.FirstName = GetFirstName(person.Country);
            person.LastName = GetLastName(person.Country);
        }
    }
}
