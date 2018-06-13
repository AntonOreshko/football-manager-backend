using System.Collections.Generic;
using DomainModels.Enums;

namespace BusinessLayer.Mappers
{
    public class CountryMapper
    {
        public Dictionary<Country, List<Country>> NamesGenerationKeys = new Dictionary<Country, List<Country>>
        {
            {
                Country.Albania, new List<Country> { Country.Albania }
            },
            {
                Country.Andorra, new List<Country> { Country.Spain }
            },
            {
                Country.Austria, new List<Country> { Country.Germany}
            },
            {
                Country.Belarus, new List<Country> { Country.Belarus, Country.Russia }
            },
            {
                Country.Belgium, new List<Country> { Country.France, Country.Nederlands }
            },
            {
                Country.Bosnia, new List<Country> { Country.Bosnia }
            },
            {
                Country.Bulgaria, new List<Country> { Country.Bulgaria }
            },
            {
                Country.Croatia, new List<Country> { Country.Croatia }
            },
            {
                Country.Czech, new List<Country> { Country.Czech }
            },
            {
                Country.Denmark, new List<Country> { Country.Denmark }
            },
            {
                Country.England, new List<Country> { Country.England }
            },
            {
                Country.Estonia, new List<Country> { Country.Estonia }
            },
            {
                Country.Finland, new List<Country> { Country.Finland }
            },
            {
                Country.France, new List<Country> { Country.France }
            },
            {
                Country.Germany, new List<Country> { Country.Germany }
            },
            {
                Country.Greece, new List<Country> { Country.Greece }
            },
            {
                Country.Hungary, new List<Country> { Country.Hungary }
            },
            {
                Country.Iceland, new List<Country> { Country.Iceland }
            },
            {
                Country.Ireland, new List<Country> { Country.Ireland, Country.England }
            },
            {
                Country.Italy, new List<Country> { Country.Italy }
            },
            {
                Country.Latvia, new List<Country> { Country.Latvia }
            },
            {
                Country.Liechtenstein, new List<Country> { Country.Germany }
            },
            {
                Country.Lithuania, new List<Country> { Country.Lithuania }
            },
            {
                Country.Luxemburg, new List<Country> { Country.France, Country.Germany }
            },
            {
                Country.Macedonia, new List<Country> { Country.Macedonia }
            },
            {
                Country.Malta, new List<Country> { Country.Italy }
            },
            {
                Country.Moldova, new List<Country> { Country.Romania }
            },
            {
                Country.Montenegro, new List<Country> { Country.Serbia }
            },
            {
                Country.Nederlands, new List<Country> { Country.Nederlands }
            },
            {
                Country.Norway, new List<Country> { Country.Norway }
            },
            {
                Country.NorthernIreland, new List<Country> { Country.Ireland, Country.England }
            },
            {
                Country.Poland, new List<Country> { Country.Poland }
            },
            {
                Country.Portugal, new List<Country> { Country.Portugal }
            },
            {
                Country.Romania, new List<Country> { Country.Romania }
            },
            {
                Country.Russia, new List<Country> { Country.Russia }
            },
            {
                Country.Scotland, new List<Country> { Country.England }
            },
            {
                Country.Serbia, new List<Country> { Country.Serbia }
            },
            {
                Country.Slovakia, new List<Country> { Country.Slovakia }
            },
            {
                Country.Slovenia, new List<Country> { Country.Slovenia }
            },
            {
                Country.Spain, new List<Country> { Country.Spain }
            },
            {
                Country.Sweden, new List<Country> { Country.Sweden }
            },
            {
                Country.Switzerland, new List<Country> { Country.Germany }
            },
            {
                Country.Turkey, new List<Country> { Country.Turkey }
            },
            {
                Country.Ukraine, new List<Country> { Country.Ukraine, Country.Russia }
            },
            {
                Country.Wales, new List<Country> { Country.England }
            },
            {
                Country.Georgia, new List<Country> { Country.Georgia }
            },
            {
                Country.Armenia, new List<Country> { Country.Armenia }
            },
            {
                Country.Azerbaijan, new List<Country> { Country.Turkey }
            },
            {
                Country.Kazahstan, new List<Country> { Country.Russia }
            },
            {
                Country.Argentina, new List<Country> { Country.Spain }
            },
            {
                Country.Bolivia, new List<Country> { Country.Spain }
            },
            {
                Country.Brazil, new List<Country> { Country.Portugal }
            },
            {
                Country.Chile, new List<Country> { Country.Spain }
            },
            {
                Country.Colombia, new List<Country> { Country.Spain }
            },
            {
                Country.Ecuador, new List<Country> { Country.Spain }
            },
            {
                Country.Guyana, new List<Country> { Country.England }
            },
            {
                Country.Paraguay, new List<Country> { Country.Spain }
            },
            {
                Country.Peru, new List<Country> { Country.Spain }
            },
            {
                Country.Suriname, new List<Country> { Country.Nederlands }
            },
            {
                Country.Uruguay, new List<Country> { Country.Spain }
            },
            {
                Country.Venezuela, new List<Country> { Country.Spain }
            },
        };
    }
}
