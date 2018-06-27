using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using BusinessLayer.Mappers;
using DomainModels.Enums;
using Newtonsoft.Json;

namespace BusinessLayer.Data
{
    public class CountryNameMap
    {
        public readonly Country Country;

        private List<string> _firstNames;

        private List<string> _lastNames;

        private Random _rnd;

        private int _firstNamesCount;

        private int _lastNamesCount;

        public CountryNameMap(Country country, CountryNameMapper nameMapper)
        {
            Country = country;
            var nameSources = nameMapper.NamesGenerationKeys[country];

            // loading of first names
            var firstNamesPathes = new List<string>();
            foreach (var c in nameSources)
            {
                firstNamesPathes.Add(Directory.GetFiles(@"Resources/PersonNames")
                    .FirstOrDefault(p => p.Contains(c.ToString()) && p.Contains("FirstNames")));
            }

            var firstNames = new List<string>();
            foreach (var p in firstNamesPathes)
            {
                var firstNamesPart = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(p));
                firstNames.AddRange(firstNamesPart);
            }

            // loading of last names
            var lastNamesPathes = new List<string>();
            foreach (var c in nameSources)
            {
                lastNamesPathes.Add(Directory.GetFiles(@"Resources/PersonNames")
                    .FirstOrDefault(p => p.Contains(c.ToString()) && p.Contains("LastNames")));
            }

            var lastNames = new List<string>();
            foreach (var p in lastNamesPathes)
            {
                var lastNamesPart = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(p));
                lastNames.AddRange(lastNamesPart);
            }

            _firstNames = firstNames;
            _lastNames = lastNames;

            _firstNamesCount = _firstNames.Count;
            _lastNamesCount = _lastNames.Count;

            _rnd = new Random();
        }

        public string GetRandomFirstName()
        {
            var idx = _rnd.Next(_firstNamesCount);

            return _firstNames[idx];
        }

        public string GetRandomLastName()
        {
            var idx = _rnd.Next(_lastNamesCount);

            return _lastNames[idx];
        }
    }
}
