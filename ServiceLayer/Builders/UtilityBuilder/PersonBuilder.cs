using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Configs;
using BusinessLayer.Data;
using BusinessLayer.Mappers;
using DomainModels.Enums;
using DomainModels.Interfaces;
using Utility;

namespace BusinessLayer.Builders.UtilityBuilder
{
    public static class PersonBuilder
    {
        private static readonly IConfigItem<CountryNameMapper> CountryNameMapperConfig;

        private static readonly HashSet<CountryNameMap> CountryNameMaps = new HashSet<CountryNameMap>();

        static PersonBuilder()
        {
            CountryNameMapperConfig = ConfigBuilder.GetConfig<CountryNameMapper>();

            var countryList = typeof(Country).ToList<Country>();

            foreach (var country in countryList)
            {
                CountryNameMaps.Add(new CountryNameMap(country, CountryNameMapperConfig.Get()));
            }
        }

        private static string GetFirstName(Country country)
        {
            return CountryNameMaps.First(cm => cm.Country == country).GetRandomFirstName();
        }

        private static string GetLastName(Country country)
        {
            return CountryNameMaps.First(cm => cm.Country == country).GetRandomLastName();
        }

        public static void SetPerson(IPerson person)
        {
            person.FirstName = GetFirstName(person.Country);
            person.LastName = GetLastName(person.Country);
        }
    }
}
